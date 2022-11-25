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
                for (int i = 0; i < 9; i++)
                {
                    GetMonsters();
                    StartFight();
                    DungeonLevel++;

                    if (GetDeadChampsCount() == 3)
                    {
                        champsAreAlive = false;
                        break;
                    }
                }

                if (champsAreAlive)
                {
                    StartBossFight();
                    DungeonLevel++;
                }
            }
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
            throw new NotImplementedException();
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

            for (int i = 0; i < _champions.Where(champion => champion.Health > 0).Count(); i++)
            {
                GetCreatures();
                Draw.Clear();
                Draw.WriteChampionStatTable(_champions);

                if (_monsters.Count == 0)
                    break;
                else
                {
                    var selectedChampion = GetChampion(Draw.SelectSingle(ParseToString(usableChampions), "Select champion"));
                    TurnAction(selectedChampion);

                    CheckForDead();

                    usedChamps.Add(selectedChampion);

                    GetCreatures();

                    if (_monsters.Count != 0)
                        MonsterFight(i);

                    CheckForDead();

                    usableChampions.Clear();
                    usableChampions.AddRange(GetUsableChampions(usedChamps));
                }
            }
        }

        private void TurnAction(Champion selected)
        {
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
            => _creatures.Where(creature => creature.Health <= 0).ToList().ForEach(creature => creature.Die());

        private int GetDeadChampsCount()
            => _champions.Where(champion => champion.Health <= 0).Count();
    }
}
