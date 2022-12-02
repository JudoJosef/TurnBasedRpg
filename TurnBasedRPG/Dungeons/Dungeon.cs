using System.Threading;
using TurnBasedRPG.Classes;
using TurnBasedRPG.Dungeons.Enemies;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Dungeons
{
    public class Dungeon
    {
        public int DungeonLevel;
        private Summoner _summoner;
        private List<IMonster> _monsters = new List<IMonster>();
        private List<Champion> _champions = new List<Champion>();
        private List<ICreature> _creatures = new List<ICreature>();

        public static bool Used = false;
        private int _championCounter;

        public Dungeon(Summoner summoner)
        {
            _summoner = summoner;
            _champions = summoner.Champions;
            DungeonLevel = 1;
        }

        public void EnterDungeon()
        {
            var champsAreAlive = true;

            while (champsAreAlive)
            {
                while (DungeonLevel % 10 != 0)
                {
                    GetMonsters();
                    StartFight();
                    DungeonLevel++;

                    if (GetDeadChampsCount() == 3)
                    {
                        champsAreAlive = false;
                        DungeonLevel--;
                        break;
                    }
                }

                if (champsAreAlive)
                {
                    StartBossFight();
                    DungeonLevel++;

                    if (GetDeadChampsCount() == 3)
                    {
                        champsAreAlive = false;
                        DungeonLevel--;
                        break;
                    }

                    if (GetDeadChampsCount() != 3 && CheckForReturn())
                    {
                        break;
                    }
                }
            }

            _champions.Where(champion =>
                champion.Health > 0)
                .ToList()
                .ForEach(champion =>
                    champion.Health = champion.MaxHealth);
        }

        private void StartFight()
        {
            do
            {
                FightGroup();
            } while (GetDeadChampsCount() != 3
                && _monsters.Count != 0);
        }

        private void StartBossFight()
        {
            _monsters.Clear();
            _monsters.Add(MonsterFactory.GetBoss(DungeonLevel));

            StartFight();
        }

        private void FightGroup()
        {
            var usedChamps = new List<Champion>();
            var usableChampions = GetUsableChampions(usedChamps);

            _creatures.ForEach(creature =>
                creature.Skills.Where(skill =>
                    skill.ActualCooldown != 0)
                    .ToList()
                .ForEach(skill => skill.ActualCooldown -= 1));

            for (_championCounter = 0; _championCounter < _champions.Where(champion => champion.Health > 0).Count(); _championCounter++)
            {
                GetCreatures();
                Draw.Clear();
                Draw.WriteLine($"Current dungeonlevel: {DungeonLevel}");
                Draw.WriteChampionFightStatTable(_champions);
                Draw.WriteMonsterStatTable(_monsters.Cast<ICreature>().ToList());

                if (_monsters.Count == 0)
                    break;
                else
                {
                    var selectedChampion = GetChampion(Draw.SelectSingle(ParseToString(usableChampions), "Select champion"));
                    TurnAction(selectedChampion);

                    if (Used)
                    {
                        CheckForDead();

                        usedChamps.Add(selectedChampion);

                        GetCreatures();

                        if (_monsters.Count != 0 && GetDeadChampsCount() != 3)
                            MonsterFight(_championCounter);

                        CheckForDead();

                        usableChampions.Clear();
                        usableChampions.AddRange(GetUsableChampions(usedChamps));
                    }
                    else
                        _championCounter--;
                }
            }
        }

        private void TurnAction(Champion selected)
        {
            Used = true;
            switch (selected.Type)
            {
                case ClassTypes.Dryad:
                    {
                        selected.TurnAction(_creatures.Concat(_champions.Where(champion => champion.Health <= 0)).ToList());
                        break;
                    }
                default:
                    {
                        selected.TurnAction(_creatures);
                        break;
                    }
            }
        }

        private void MonsterFight(int index)
        {
            if (index > _monsters.Count() || index == _monsters.Count())
                _monsters.First()
                    .TurnAction(_creatures.Where(creature =>
                        typeof(IAlly).IsAssignableFrom(creature.GetType()))
                            .ToList());
            else
                _monsters.ElementAt(index)
                    .TurnAction(_creatures.Where(creature =>
                        typeof(IAlly).IsAssignableFrom(creature.GetType()))
                            .ToList());
        }

        private List<Champion> GetUsableChampions(List<Champion> usedChamps)
            => _champions.Where(champion =>
                champion.Health > 0
                && !usedChamps.Contains(champion)).ToList();

        private void GetCreatures()
        {
            _creatures.Clear();
            _creatures.AddRange(_champions.Where(champion => champion.Health > 0));
            _monsters.Where(monster => monster.Health <= 0).ToList().ForEach(monster => _monsters.Remove(monster));
            _creatures.AddRange(_monsters);
        }

        private Champion GetChampion(string type)
            => _champions.Where(champion =>
                champion.Type == Game.ParseToClassType(type))
                .Single();

        private List<string> ParseToString(List<Champion> champions)
            => champions.Select(champion => champion.Type.ToString()).ToList();

        private void GetMonsters()
            => _monsters = MonsterFactory.GetMonsters(DungeonLevel);

        private void CheckForDead()
        {
            var deadCreatures = _creatures.Where(creature => creature.Health <= 0).ToList();
            deadCreatures.ForEach(creature => creature.Die());

            var deadMonsters = deadCreatures.Where(creature =>
                typeof(IMonster).IsAssignableFrom(creature.GetType()))
                    .ToList();

            var rnd = new Random();

            for (int i = 0; i < deadMonsters.Count(); i++)
            {
                var lootAmount = rnd.Next(3, 6) * DungeonLevel;
                var goldAmount = (int)(25 * GetMultiplicator());

                _summoner.Inventory.Gold += goldAmount;

                var keys = _summoner.Inventory.Loot.Keys;

                foreach (var key in keys)
                {
                    _summoner.Inventory.Loot[key].Value += lootAmount;
                }
            }

            if (deadMonsters.Any() &&
                !_summoner.DefeatedCreatures.Where(creature =>
                    creature.Type == ((IMonster)deadMonsters.First()).Type)
                .Any())
            {
                var monster = deadMonsters.First();
                _summoner.DefeatedCreatures.Add((IMonster)monster);
            }

            deadMonsters.ForEach(monster => _champions.ForEach(champion => champion.Experience += ((IMonster)monster).ExperienceToDrop));
            _champions.ForEach(champion => champion.LevelUp());
        }

        private int GetDeadChampsCount()
            => _champions.Where(champion => champion.Health <= 0).Count();

        private double GetMultiplicator()
            => ((double)DungeonLevel / 10) + 1;

        private bool CheckForReturn()
        {
            Draw.Clear();
            return Draw.SelectSingle(new List<string> { "Return to Lobby", "Continue" }, "Return to lobby or continue?") == "Return to Lobby";
        }
    }
}
