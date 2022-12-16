using TurnBasedRPG.Champions;
using TurnBasedRPG.Lobby;
using TurnBasedRPG.Player;

namespace TurnBasedRPG;

public class Game
{
    private Summoner _summoner = CreateSummoner();
    private static ChampionInspector _inspector = new ChampionInspector();

    public void Run()
    {
        var lobby = new Hub(_summoner, _inspector);
        lobby.EnterLobby();
    }

    public static ClassTypes ParseToClassType(string type)
        => Enum.Parse<ClassTypes>(type);

    private static Summoner CreateSummoner()
        => new Summoner(GetChampions(), new SummonerInventory());

    private static List<Champion> GetChampions()
        => _inspector.SelectChampions(ChampionFactory.SummonChampions());
}
