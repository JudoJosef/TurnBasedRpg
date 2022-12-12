using Microsoft.Data.Sqlite;
using TurnBasedRPG.Champions;
using TurnBasedRPG.Dungeons.Enemies;
using TurnBasedRPG.Lobby.Items;
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
        using var reader = command.ExecuteReader();
        reader.Read();

        if (reader.HasRows)
        {
            return ParseSummoner();
        }

        return null;
    }

    public int GetId()
    {
        using var command = _connection.CreateCommand($"Select id from {SummonerTableName}");
        using var reader = command.ExecuteReader();
        reader.Read();

        return ParseToInt(reader, "id");
    }

    private Summoner ParseSummoner()
    {
        var summonerId = GetId();
        var champions = GetChampions(summonerId);
        var inventory = GetInventory(summonerId);
        var defeatedCreatures = GetDefeatedCreatures(summonerId);

        var summoner = new Summoner(champions, inventory, summonerId);
        summoner.DefeatedCreatures = defeatedCreatures;

        return summoner;
    }

    private List<Champion> GetChampions(int summonerId)
    {
        using var command = _connection.CreateCommand($"select * from {ChampionTableName} where {SummonerTableName} = {summonerId}");
        using var reader = command.ExecuteReader();

        return new List<Champion>
        {
            ParseToChampion(reader),
            ParseToChampion(reader),
            ParseToChampion(reader),
        };
    }

    private SummonerInventory GetInventory(int summonerId)
    {
        using var command = _connection.CreateCommand(
            $"Select * from {SummonerInventoryTableName} si " +
            $"join {SummonerTableName} s on s.{SummonerInventoryTableName} = si.id" +
            $"where s.id = {summonerId}");
        using var reader = command.ExecuteReader();
        reader.Read();

        var loot = GetLoot(reader);
        var gold = ParseToInt(reader, GoldColumn);
        var items = GetItems((long)reader["id"]);

        var inventory = new SummonerInventory();
        inventory.Loot = loot;
        inventory.Gold = gold;
        inventory.Items = items;

        return inventory;
    }

    private List<IMonster> GetDefeatedCreatures(int summonerId)
    {
        using var command = _connection.CreateCommand(
            $"Select * from {BookOfMonstersTableName} bom " +
            $"join {SummonerTableName}_{BookOfMonstersTableName} s_b on s_b.Monster_id = bom.Name " +
            $"where s_b.Summoner_id = {summonerId}");
        using var reader = command.ExecuteReader();
        var defeatedCreatures = new List<IMonster>();

        while (reader.Read())
        {
            defeatedCreatures.Add(MonsterFactory.GetMonster((EnemyTypes)ParseToInt(reader, "Name")));
        }

        return defeatedCreatures;
    }

    private Champion ParseToChampion(SqliteDataReader reader)
    {
        reader.Read();

        var statsId = ParseToInt(reader, StatsTableName);
        var classType = (ClassTypes)ParseToInt(reader, ClassTypeColumn);

        var stats = GetStats(statsId);

        var skills = GetSkills(classType);

        var champion = new Champion(
            stats.Health,
            stats.Armor,
            stats.MagicDefense,
            stats.Strength,
            skills,
            classType);

        SetChampionValues(reader, champion);

        return champion;
    }

    private (int Health, int Strength, int Armor, int MagicDefense) GetStats(int statsId)
    {
        using var command = _connection.CreateCommand($"Select * from {StatsTableName} where id = {statsId}");
        using var reader = command.ExecuteReader();
        reader.Read();

        return (
            ParseToInt(reader, HealthColumn),
            ParseToInt(reader, StrengthColumn),
            ParseToInt(reader, ArmorColumn),
            ParseToInt(reader, MagicDefenseColumn));
    }

    private Item? GetItem(long id)
    {
        using var command = _connection.CreateCommand($"Select * from {ItemTableName} where id = {id}");
        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            var statsId = ParseToInt(reader, StatsTableName);
            var stats = GetStats(statsId);
            var level = ParseToInt(reader, LevelColumn);
            var itemType = (ItemTypes)ParseToInt(reader, ItemTypeColumn);
            var index = ParseToInt(reader, NameColumn);
            var rarity = (ItemRarity)ParseToInt(reader, RarityColumn);
            var name = ItemFactory.GetName(itemType, index);
            var price = ParseToInt(reader, PriceColumn);

            return new Item(itemType, name, rarity, price, new Dictionary<StatTypes, int>
            {
                { StatTypes.Health, stats.Health },
                { StatTypes.Strength, stats.Strength },
                { StatTypes.Armor, stats.Armor },
                { StatTypes.MagicDefense, stats.MagicDefense },
            });
        }

        return null;
    }

    private Dictionary<LootTypes, LootAmount> GetLoot(SqliteDataReader reader)
    {
        var loot = new Dictionary<LootTypes, LootAmount>
        {
            { LootTypes.Leather, new LootAmount() },
            { LootTypes.Scales, new LootAmount() },
            { LootTypes.Silk, new LootAmount() },
            { LootTypes.Orcteeth, new LootAmount() },
            { LootTypes.Scrap, new LootAmount() },
        };

        loot[LootTypes.Leather].Value = ParseToInt(reader, LeatherColumn);
        loot[LootTypes.Scales].Value = ParseToInt(reader, ScalesColumn);
        loot[LootTypes.Silk].Value = ParseToInt(reader, SilkColumn);
        loot[LootTypes.Orcteeth].Value = ParseToInt(reader, OrcTeethColumn);
        loot[LootTypes.Scrap].Value = ParseToInt(reader, ScrapColumn);

        return loot;
    }

    private Dictionary<ItemTypes, Item> GetItems(SqliteDataReader reader)
        => new Dictionary<ItemTypes, Item>
        {
            { ItemTypes.Helmet, GetItem((long)reader[HelmetColumn])! },
            { ItemTypes.Chestplate, GetItem((long)reader[ChestplateColumn])! },
            { ItemTypes.Leggins, GetItem((long)reader[LegginsColumn])! },
            { ItemTypes.Boots, GetItem((long)reader[BootsColumn])! },
            { ItemTypes.Accessoire, GetItem((long)reader[WeaponColumn])! },
            { ItemTypes.Weapon, GetItem((long)reader[AccessoireColumn])! },
        }
        .Where(item => item.Value is not null)
        .ToDictionary(item => item.Key, item => item.Value);

    private void SetChampionValues(SqliteDataReader reader, Champion champion)
    {
        var experience = ParseToInt(reader, ExperienceColumn);
        var neededExperience = ParseToInt(reader, NeededExperienceColumn);
        var level = ParseToInt(reader, LevelColumn);
        var shield = ParseToInt(reader, ShieldColumn);
        var maxHealth = ParseToInt(reader, MaxHealthColumn);
        var items = GetItems(reader);

        champion.Shield = shield;
        champion.MaxHealth = maxHealth;
        champion.Level = level;
        champion.Experience = experience;
        champion.NeededExperience = neededExperience;
        champion.Inventory.Items = items;
    }

    private Dictionary<int, Item> GetItems(long inventoryId)
    {
        using var command = _connection.CreateCommand(
            $"Select * from {ItemTableName}_{SummonerInventoryTableName} i_s " +
            $"join {SummonerInventoryTableName} si on si.id = i_s.si_id " +
            $"where si.id = {inventoryId}");
        using var reader = command.ExecuteReader();

        var items = new Dictionary<int, Item>();
        var counter = 0;

        while (reader.Read())
        {
            items.Add(counter, GetItem((long)reader["id"])!);
            counter++;
        }

        return items;
    }

    private List<Skill> GetSkills(ClassTypes type)
        => ChampionFactory.GetSkillSet(type);

    private int ParseToInt(SqliteDataReader reader, string column)
        => (int)(long)reader[column];
}
