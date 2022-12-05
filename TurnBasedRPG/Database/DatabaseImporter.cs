using Microsoft.Data.Sqlite;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Database
{
    public class DatabaseImporter
    {
        private readonly SqliteConnection _connection;

        public DatabaseImporter(SqliteConnection connection)
        {
            _connection = connection;
        }

        public void ImportSummoner(Summoner summoner)
        {
            throw new NotImplementedException();
        }
    }
}
