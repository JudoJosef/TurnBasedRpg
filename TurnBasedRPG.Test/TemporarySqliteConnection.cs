using Messerli.TempDirectory;
using Microsoft.Data.Sqlite;
using TurnBasedRPG.Database;

namespace TurnBasedRPG.Test
{
    public sealed class TemporarySqliteConnection : IDisposable
    {
        private readonly TempDirectory _tempDirectory;

        public TemporarySqliteConnection()
        {
            _tempDirectory = new TempDirectoryBuilder().Create();
            Value = new SqliteConnection($"Data Source={Path.Combine(_tempDirectory.FullName, "turnBasedRpg.db")}");
            Value.Open();
        }

        public SqliteConnection Value { get; }

        public static implicit operator SqliteConnection(TemporarySqliteConnection temporarySqliteConnection) => temporarySqliteConnection.Value;

        public void Dispose()
        {
            Value.Dispose();
            _tempDirectory.Dispose();
        }

        public SqliteCommand CreateCommand(string command)
            => Value.CreateCommand(command);
    }
}