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
        private void GetChampions()
        {
            var selectedChampions = Draw.SelectChampions();
            selectedChampions.ForEach(championType => _champions.Add(SummonChampion(championType)));
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
