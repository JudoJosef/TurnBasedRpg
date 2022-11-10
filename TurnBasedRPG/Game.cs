using TurnBasedRPG.Classes;
using TurnBasedRPG.Enemies;
using TurnBasedRPG.Player;

namespace TurnBasedRPG
{
    internal class Game
    {
        private List<Champion> _champions = new List<Champion>();
        private List<IMonster> _monsters = new List<IMonster>();
        private List<ICreature> _creatures = new List<ICreature>();

        public void Run()
        {
            GetChampions();

            StartFight();
        }

        private void StartFight()
        {
            do
            {
                PlayerTurn();
            } while (_champions.Where(champion => champion.Health <= 0).Count() == 3);
        }

        private void PlayerTurn()
        {
            var usedChamps = new List<Champion>();
            var usableChampions = GetUsableChampions(usedChamps);

            for (int i = 0; i < usableChampions.Count; i++)
            {
                GetCreatures();

                var selectedChampion = Draw.SelectChampionTurn(usableChampions);
                selectedChampion.TurnAction(_creatures);

                usedChamps.Add(selectedChampion);
                usableChampions.Clear();
                usableChampions.AddRange(GetUsableChampions(usedChamps));
            }
        }

        private List<Champion> GetUsableChampions(List<Champion> usedChamps)
            => _champions.Where(champion =>
                champion.Health > 0
                && !usedChamps.Contains(champion)).ToList();

        private void GetChampions()
        {
            var selectedChampions = Draw.SelectChampions();
            selectedChampions.ForEach(championType => _champions.Add(SummonChampion(championType)));
        }

        private void GetCreatures()
        {
            _creatures.Clear();
            _creatures.AddRange(_champions);
            _creatures.AddRange(_monsters);
        }

        private Champion SummonChampion(ClassTypes type)
            => type switch
            {
                ClassTypes.Archer => Portal.SummonArcher(),
                ClassTypes.Assassin => Portal.SummonAssassin(),
                ClassTypes.Dryad => Portal.SummonDryad(),
                ClassTypes.Fighter => Portal.SummonFighter(),
                ClassTypes.Jojo => Portal.CallJojo(),
                ClassTypes.Mage => Portal.SummonMage(),
                ClassTypes.Paladin => Portal.SummonPaladin(),
                ClassTypes.Swordsman => Portal.SummonSwordsman(),
                _ => throw new NotImplementedException()
            };
    }
}
