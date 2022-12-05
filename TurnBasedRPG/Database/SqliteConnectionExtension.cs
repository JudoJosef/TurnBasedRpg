using Microsoft.Data.Sqlite;

namespace TurnBasedRPG.Database
{
    public static class SqliteConnectionExtension
    {
        public static SqliteCommand CreateCommand(this SqliteConnection connection, string command)
        {
            var sqliteCommand = connection.CreateCommand();
            sqliteCommand.CommandText = command;
            return sqliteCommand;
        }
    }
}
