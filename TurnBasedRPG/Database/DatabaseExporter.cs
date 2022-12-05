using Microsoft.Data.Sqlite;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Database
{
    public class DatabaseExporter
    {
        private readonly SqliteConnection _connection;

        public DatabaseExporter(SqliteConnection connection)
        {
            _connection = connection;
        }

        public Summoner? GetSummoner()
        {
            throw new NotImplementedException();
        }

        public int GetId()
        {
            throw new NotImplementedException();
        }
    }
}
