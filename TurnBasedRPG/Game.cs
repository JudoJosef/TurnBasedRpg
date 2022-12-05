using TurnBasedRPG.Classes;
using TurnBasedRPG.Lobby;
using TurnBasedRPG.Player;

namespace TurnBasedRPG
{
    public class Game
    {
        private Summoner _summoner = null!;
        private ChampionInspector _inspector = new ChampionInspector();

        public void Run()
        {
            _summoner = CreateSummoner();
            var lobby = new Hub(_summoner, _inspector);
            lobby.EnterLobby();
        }

        public static ClassTypes ParseToClassType(string type)
            => Enum.Parse<ClassTypes>(type);

        private Summoner CreateSummoner()
            => new Summoner(GetChampions(), new SummonerInventory());

        private List<Champion> GetChampions()
            => _inspector.SelectChampions(ChampionFactory.SummonChampions());
    }
}
