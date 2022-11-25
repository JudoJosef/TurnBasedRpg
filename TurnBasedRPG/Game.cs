using TurnBasedRPG.Classes;
using TurnBasedRPG.Lobby;
using TurnBasedRPG.Player;

namespace TurnBasedRPG
{
    public class Game
    {
        private Summoner _summoner = CreateSummoner();

        public void Run()
        {
            var lobby = new Hub(_summoner);
            lobby.EnterLobby();
        }

        public static ClassTypes ParseToClassType(string type)
            => Enum.Parse<ClassTypes>(type);

        private static Summoner CreateSummoner()
            => new Summoner(GetChampions(), new SummonerInventory());

        private static Champion SummonChampion(ClassTypes type)
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

        private static List<Champion> GetChampions()
            => Draw.SelectChampions()
                .Select(type => ParseToClassType(type))
                .Select(championType => SummonChampion(championType))
                .ToList();
    }
}
