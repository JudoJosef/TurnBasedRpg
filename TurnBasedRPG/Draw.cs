using Spectre.Console;
using Spectre.Console.Rendering;
using TurnBasedRPG.Classes;
using TurnBasedRPG.Dungeons.Enemies;
using TurnBasedRPG.Lobby;
using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG
{
    public static class Draw
    {
        private static List<string> _availableChampions = new List<string>
        {
            ClassTypes.Archer.ToString(),
            ClassTypes.Assassin.ToString(),
            ClassTypes.Dryad.ToString(),
            ClassTypes.Fighter.ToString(),
            ClassTypes.Jojo.ToString(),
            ClassTypes.Mage.ToString(),
            ClassTypes.Paladin.ToString(),
            ClassTypes.Swordsman.ToString(),
        };

        private static List<string> _selectedChampions = new List<string>();

        public static List<string> SelectChampions()
        {
            while (_selectedChampions.Count < 3)
            {
                var selected = SelectSingle(GetChoices(_availableChampions), "Select champions");
                _selectedChampions.Add(selected);
            }

            return _selectedChampions;
        }

        public static string SelectSingle(IEnumerable<string> options, string title)
            => AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title(title)
                .AddChoices(options.ToList()));

        public static void Clear()
            => AnsiConsole.Clear();

        public static void WriteLine(string line)
            => AnsiConsole.MarkupLine(line);

        public static void WriteLineAndWait(string line)
        {
            AnsiConsole.MarkupLine(line);
            Console.ReadKey();
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

        public static void WriteMonsterStatTable(List<ICreature> creatures)
        {
            var table = new Table();

            table.AddColumn(new TableColumn("Stats").Centered());
            creatures.ForEach(creature => table.AddColumn(new TableColumn(((Monster)creature).Type.ToString())));
            AddRows(creatures, table);

            AnsiConsole.Write(table);
        }

        private static void AddRows(Table table, int craftingCost, SummonerInventory inventory)
            => Constants.AllLootTypes.ForEach(lootType => table.AddRow(new string[] { lootType.ToString(), $"{inventory.Loot[lootType].Value}/{craftingCost}" }));

        private static void AddRows(List<Item> items, Table table)
        {
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

        private static List<string> GetChoices(List<string> current)
            => current.Where(champion =>
                !_selectedChampions.Contains(champion))
                .ToList();

        private static string GetRarity(ItemRarity rarity)
            => rarity switch
            {
                ItemRarity.Common => $"[grey70]{rarity}[/]",
                ItemRarity.Uncommon => $"[green4]{rarity}[/]",
                ItemRarity.Rare => $"[dodgerblue2]{rarity}[/]",
                ItemRarity.Epic => $"[magenta3_2]{rarity}[/]",
                ItemRarity.Legendary => $"[gold3_1]{rarity}[/]",
                ItemRarity.Mythic => $"[red3_1]{rarity}[/]",
                _ => throw new Exception()
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
    }
}
