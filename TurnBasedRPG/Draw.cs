using Spectre.Console;
using TurnBasedRPG.Classes;
using TurnBasedRPG.Lobby.Items;

namespace TurnBasedRPG
{
    internal static class Draw
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

        public static void WriteItemTable(List<Item> items)
        {
            var table = new Table();

            table.AddColumn(new TableColumn("Stats").Centered());
            items.ForEach(item => table.AddColumn(new TableColumn(item.Name).Centered()));
            AddRows(items, table);

            AnsiConsole.Write(table);
        }

        private static void AddRows(List<Item> items, Table table)
        {
            table.AddRow(new string[] { "Price" }.Concat(items.Select(item => item.Price.ToString())).ToArray());
            table.AddRow(new string[] { "Rarity" }.Concat(items.Select(item => GetRarity(item.Rarity))).ToArray());
            AddStatRow("Health", StatTypes.Health, table, items);
            AddStatRow("Armor", StatTypes.Armor, table, items);
            AddStatRow("Magic Defense", StatTypes.MagicDefense, table, items);
            AddStatRow("Strength", StatTypes.Strength, table, items);
        }

        private static void AddStatRow(string category, StatTypes type, Table table, List<Item> items)
            => table.AddRow(new string[] { category }.Concat(items.Select(item => item.Stats[type].ToString())).ToArray());

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
    }
}
