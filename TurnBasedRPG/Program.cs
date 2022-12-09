using Microsoft.Data.Sqlite;
using TurnBasedRPG.Database;

namespace TurnBasedRPG
{
    public class Program
    {
        static void Main()
        {
            var connection = GetConnection();
            connection.Open();

            var game = new Game(connection);
            game.Run();

            connection.Close();
        }

        private static SqliteConnection GetConnection()
        {
            var dbName = "turnBasedRpg.db";
            var directory = Path.Combine("..", "..", "..", "Db");
            var fullPath = Path.Combine(directory, dbName);

            return new SqliteConnection($"Data Source={fullPath}");
        }
    }
}