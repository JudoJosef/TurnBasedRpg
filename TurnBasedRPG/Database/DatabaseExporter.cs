﻿using Microsoft.Data.Sqlite;
using TurnBasedRPG.Player;
using static TurnBasedRPG.Database.DatabaseDetails;

namespace TurnBasedRPG.Database;

public class DatabaseExporter
{
    private readonly SqliteConnection _connection;

    public DatabaseExporter(SqliteConnection connection)
    {
        _connection = connection;
    }

    public Summoner? GetSummoner()
    {
        using var command = _connection.CreateCommand($"Select * from {SummonerTableName}");
        throw new NotImplementedException();
    }

    public int GetId()
    {
        throw new NotImplementedException();
    }
}
