using TurnBasedRPG.Database;

namespace TurnBasedRPG.Test
{
    public class DatabaseInitializerTest
    {
        [Fact]
        public void TableIsCreated()
        {
            using var connection = new TemporarySqliteConnection();

            DatabaseInitializer.Create(connection).CreateTable("person");

            using var command = connection.CreateCommand("SELECT * FROM person");
            using var reader = command.ExecuteReader();
        }
    }
}