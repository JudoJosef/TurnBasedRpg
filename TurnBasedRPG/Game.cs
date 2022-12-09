using Microsoft.Data.Sqlite;
using TurnBasedRPG.Champions;
using TurnBasedRPG.Database;
using TurnBasedRPG.Lobby;
using TurnBasedRPG.Player;

namespace TurnBasedRPG;

public class Game
{
    private readonly DatabaseExporter _dbExporter;
    private Summoner _summoner = null!;
    private ChampionInspector _inspector = new ChampionInspector();

    public Game(SqliteConnection connection)
    {
        _dbExporter = new DatabaseExporter(connection);
    }

    public void Run()
    {
        _summoner = _dbExporter.GetSummoner()!;

        if (_summoner is null)
        {
            _summoner = CreateSummoner();
        }

        var lobby = new Hub(_summoner, _inspector);
        lobby.EnterLobby();
    }

    public static ClassTypes ParseToClassType(string type)
        => Enum.Parse<ClassTypes>(type);

    private Summoner CreateSummoner()
        => new Summoner(GetChampions(), new SummonerInventory(), _dbExporter.GetId());

    private List<Champion> GetChampions()
        => _inspector.SelectChampions(ChampionFactory.SummonChampions());
}
