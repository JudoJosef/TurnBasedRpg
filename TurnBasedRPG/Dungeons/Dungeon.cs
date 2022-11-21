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
    }
}
