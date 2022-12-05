using Microsoft.Data.Sqlite;
using static TurnBasedRPG.Database.DatamodelAssembler;
using static TurnBasedRPG.Database.DatabaseDetails;

namespace TurnBasedRPG.Database
{
    public class DatabaseInitializer
    {
        private readonly SqliteConnection _connection;

        public DatabaseInitializer(SqliteConnection connection)
        {
            _connection = connection;
        }

        public void CreateDatabase()
        {
            TableNames.ForEach(tableName => CreateTable(tableName));

            var columnDetails = AssembleSummonerDatamodel()
                .Concat(AssembleChampionDatamodel())
                .Concat(AssembleBookOfMonstersDatamodel())
                .Concat(AssembleInventoryDatamodel())
                .Concat(AssembleItemDatamodel())
                .Concat(AssembleStatsDatamodel())
                .ToList();

            CreateColumns(columnDetails);
        }

        private void CreateTable(string name)
        {
            using var command = _connection.CreateCommand(
                $"CREATE TABLE {name} (id INTEGER PRIMARY KEY)");
            command.ExecuteNonQuery();
        }

        private void CreateColumns(List<ColumnDetails> columnDetails)
            => columnDetails.ForEach(columnDetail => CreateColumn(columnDetail));

        private void CreateColumn(ColumnDetails details)
        {
            using var command = _connection.CreateCommand(
                $"ALTER TABLE {details.TableName} " +
                $"ADD COLUMN {details.Name} " +
                $"{details.Type}");
            command.ExecuteNonQuery();
        }
    }
}
