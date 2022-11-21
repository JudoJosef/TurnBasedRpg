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
            while (true)
            {
                for (int i = 0; i < 9; i++)
                {
                    GetMonsters();
                    StartFight();
                    DungeonLevel++;
                }

                StartBossFight();
                DungeonLevel++;
            }
        }

        private void StartFight()
        {
            do
            {
                FightGroup();
                if (_monsters.Count == 0)
                    break;
            } while (_champions.Where(champion => champion.Health <= 0).Count() != 3);
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

            for (int i = 0; i < _champions.Count; i++)
            {
                GetCreatures();
                Draw.Clear();

                if (_monsters.Count == 0)
                    break;
                else
                {
                    var selectedChampion = GetChampion(Draw.SelectSingle(ParseToString(usableChampions), "Select champion"));
                    if (selectedChampion.Type == ClassTypes.Dryad)
                        selectedChampion.TurnAction(_summoner.Champions.Cast<ICreature>().ToList());
                    selectedChampion.TurnAction(_creatures);

                    usedChamps.Add(selectedChampion);
                }

                MonsterFight(i);

                usableChampions.Clear();
                usableChampions.AddRange(GetUsableChampions(usedChamps));
            }
        }

        private void MonsterFight(int index)
            => _monsters.ElementAt(index)
                .TurnAction(_creatures.Where(creature =>
                    typeof(IMonster).IsAssignableFrom(creature.GetType()))
                        .ToList());

        private List<Champion> GetUsableChampions(List<Champion> usedChamps)
            => _champions.Where(champion =>
                champion.Health > 0
                && !usedChamps.Contains(champion)).ToList();
    }
}
