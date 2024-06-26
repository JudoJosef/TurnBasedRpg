﻿using Spectre.Console;
using TurnBasedRPG.Champions;
using TurnBasedRPG.Dungeons.Enemies;
using TurnBasedRPG.Lobby;
using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG;

public static class Draw
{
    public static string SelectSingle(IEnumerable<string> options, string title)
        => AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title(title)
            .AddChoices(options.ToList()));

    public static string GetLine(string line)
        => AnsiConsole.Ask<string>(line);

    public static void Clear()
        => AnsiConsole.Clear();

    public static void WriteLine(string line)
        => AnsiConsole.MarkupLine(line);

    public static void WriteLineAndWait(string line)
    {
        AnsiConsole.MarkupLine(line);
        Console.ReadKey();
    }

    public static void WriteMinerTable(IEnumerable<Miner> miners)
    {
        var table = new Table();

        table.AddColumn(new TableColumn("Stats").Centered());
        GetMinerHeaders(miners, table);
        AddRows(table, miners);

        AnsiConsole.Write(table);
    }

    public static void WriteLootTable(ItemRarity rarity, SummonerInventory inventory, int craftingCost)
    {
        var table = new Table();

        table.AddColumn(new TableColumn("Materials").Centered());
        table.AddColumn(new TableColumn(rarity.ToString()).Centered());
        AddRows(table, craftingCost, inventory);

        AnsiConsole.Write(table);
    }

    public static void WriteItemTable(List<Item> items)
    {
        var table = new Table();

        table.AddColumn(new TableColumn("Stats").Centered());
        items.ForEach(item => table.AddColumn(new TableColumn(item.Name).Centered()));
        AddRows(items, table);

        AnsiConsole.Write(table);
    }

    public static void WriteChampionStatTable(List<Champion> champions)
    {
        var table = new Table();

        table.AddColumn(new TableColumn("Stats").Centered());
        champions.ForEach(champion => table.AddColumn(new TableColumn(champion.Type.ToString())));
        AddRows(champions, table);

        AnsiConsole.Write(table);
    }

    public static void WriteChampionFightStatTable(List<Champion> champions)
    {
        var table = new Table();

        table.AddColumn(new TableColumn("Stats").Centered());
        champions.ForEach(champion => table.AddColumn(new TableColumn(champion.Type.ToString())));
        AddRows(champions, table);
        AddRows(table, champions);

        AnsiConsole.Write(table);
    }

    public static void WriteMonsterStatTable(List<ICreature> creatures)
    {
        var table = new Table();

        table.AddColumn(new TableColumn("Stats").Centered());
        creatures.ForEach(creature => table.AddColumn(new TableColumn(((IMonster)creature).Type.ToString())));
        AddRows(creatures, table);

        AnsiConsole.Write(table);
    }

    private static void AddRows(Table table, IEnumerable<Miner> miners)
    {
        table.AddRow(new List<string> { "Level" }
            .Concat(miners.Select(miner => miner.Level.ToString())).ToArray());
        table.AddRow(new List<string> { "Upgradecost" }
            .Concat(miners.Select(miner => miner.UpgradeCost.ToString())).ToArray());
    }

    private static void AddRows(Table table, List<Champion> champions)
    {
        table.AddRow(
            new string[] { "1. Skill" }
            .Concat(new List<string>
            {
                ParseToRow(champions.ElementAt(0).Skills.ElementAt(0).ActualCooldown),
                ParseToRow(champions.ElementAt(1).Skills.ElementAt(0).ActualCooldown),
                ParseToRow(champions.ElementAt(2).Skills.ElementAt(0).ActualCooldown),
            }).ToArray());

        table.AddRow(
            new string[] { "2. Skill" }
            .Concat(new List<string>
            {
                ParseToRow(champions.ElementAt(0).Skills.ElementAt(1).ActualCooldown),
                ParseToRow(champions.ElementAt(1).Skills.ElementAt(1).ActualCooldown),
                ParseToRow(champions.ElementAt(2).Skills.ElementAt(1).ActualCooldown),
            }).ToArray());

        table.AddRow(
            new string[] { "3. Skill" }
            .Concat(new List<string>
            {
                ParseToRow(champions.ElementAt(0).Skills.ElementAt(2).ActualCooldown),
                ParseToRow(champions.ElementAt(1).Skills.ElementAt(2).ActualCooldown),
                ParseToRow(champions.ElementAt(2).Skills.ElementAt(2).ActualCooldown),
            }).ToArray());
    }

    private static void AddRows(Table table, List<Skill> skills)
        => table.AddRow(skills.Select(skill => ParseToRow(skill.ActualCooldown)).ToArray());

    private static void AddRows(Table table, int craftingCost, SummonerInventory inventory)
        => Constants.AllLootTypes.ForEach(lootType => table.AddRow(new string[] { lootType.ToString(), $"{inventory.Loot[lootType].Value}/{craftingCost}" }));

    private static void AddRows(List<Item> items, Table table)
    {
        table.AddRow(new string[] { "Level" }.Concat(items.Select(item => item.Level.ToString())).ToArray());
        table.AddRow(new string[] { "Price" }.Concat(items.Select(item => item.Price.ToString())).ToArray());
        table.AddRow(new string[] { "Rarity" }.Concat(items.Select(item => GetRarity(item.Rarity))).ToArray());
        table.AddRow(new string[] { "Type" }.Concat(items.Select(item => item.Type.ToString())).ToArray());
        AddStatRow("Health", StatTypes.Health, table, items);
        AddStatRow("Armor", StatTypes.Armor, table, items);
        AddStatRow("Magic Defense", StatTypes.MagicDefense, table, items);
        AddStatRow("Strength", StatTypes.Strength, table, items);
    }

    private static void AddRows(List<Champion> champions, Table table)
    {
        var health = champions.Select(champion => champion.Health);
        var maxHealth = champions.Select(champion => champion.MaxHealth);
        var shield = champions.Select(champion => champion.Shield);
        var armor = champions.Select(champion => champion.Armor);
        var magicResist = champions.Select(champion => champion.MagicDefense);
        var strength = champions.Select(champion => champion.Strength);
        var level = champions.Select(champion => champion.Level);

        AddStatRow("Level", level, table);
        AddStatRow("Health", table, GetHealthView(health, maxHealth));
        AddStatRow("Shield", shield, table);
        AddStatRow("Armor", armor, table);
        AddStatRow("Magic Defense", magicResist, table);
        AddStatRow("Strength", strength, table);
    }

    private static void AddRows(List<ICreature> creatures, Table table)
    {
        AddStatRow("Health", table, creatures.Select(creature => creature.Health.ToString()));
        AddStatRow("Armor", table, creatures.Select(creature => creature.Armor.ToString()));
        AddStatRow("Magic Defense", table, creatures.Select(creature => creature.MagicDefense.ToString()));
        AddStatRow("Strength", table, creatures.Select(creature => creature.Strength.ToString()));
    }

    private static void AddStatRow(string category, StatTypes type, Table table, List<Item> items)
        => table.AddRow(new string[] { category }.Concat(items.Select(item => item.Stats[type].ToString())).ToArray());

    private static void AddStatRow(string category, IEnumerable<int> values, Table table)
        => table.AddRow(new string[] { category }.Concat(values.Select(value => value.ToString())).ToArray());

    private static void AddStatRow(string category, Table table, IEnumerable<string> values)
        => table.AddRow(new string[] { category }.Concat(values).ToArray());

    private static string GetRarity(ItemRarity rarity)
        => rarity switch
        {
            ItemRarity.Common => $"[grey70]{rarity}[/]",
            ItemRarity.Uncommon => $"[green4]{rarity}[/]",
            ItemRarity.Rare => $"[dodgerblue2]{rarity}[/]",
            ItemRarity.Epic => $"[magenta3_2]{rarity}[/]",
            ItemRarity.Legendary => $"[gold3_1]{rarity}[/]",
            ItemRarity.Mythic => $"[red3_1]{rarity}[/]",
            _ => throw new Exception(),
        };

    private static int GetStat(Champion champion, StatTypes type)
    {
        var stat = 0;
        champion.Inventory.Items.Values.ToList().ForEach(item => stat += item.Stats[type]);
        return stat;
    }

    private static IEnumerable<string> GetHealthView(IEnumerable<int> health, IEnumerable<int> maxHalth)
    {
        var output = new List<string>();
        for (int i = 0; i < health.Count(); i++)
        {
            output.Add($"{health.ElementAt(i)}/{maxHalth.ElementAt(i)}");
        }

        return output;
    }

    private static void GetMinerHeaders(IEnumerable<Miner> miners, Table table)
    {
        var counter = 0;
        table.AddColumns(miners.Select(miner =>
        {
            var result = $"Miner Nr. {counter}";
            counter++;
            return new TableColumn(result).Centered();
        }).ToArray());
    }

    private static string ParseToRow(int value)
        => value != 0
            ? $"Cooldown: {value}"
            : "Ready";
}
