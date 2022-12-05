using Microsoft.Data.Sqlite;
using TurnBasedRPG.Database;

namespace TurnBasedRPG
{
    public class Program
    {
        static void Main()
        {
            var connection = TryCreateDatabase();

            var game = new Game(connection);
            game.Run();

            connection.Close();
        }

        private static SqliteConnection TryCreateDatabase()
        {
            var dbName = "turnBasedRpg.db";
            var directory = Directory.CreateDirectory("test");
            var fullPath = Path.Combine(directory.FullName, dbName);
            SqliteConnection connection = null!;

            if (!File.Exists(fullPath))
            {
                connection = new SqliteConnection($"Data Source={fullPath}");
                connection.Open();

                var dbInitializer = new DatabaseInitializer(connection);
                dbInitializer.CreateDatabase();
            }
            else
            {
                connection = new SqliteConnection($"Data Source={fullPath}");
                connection.Open();
            }

            return connection;
        }
    }
}