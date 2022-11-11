using Spectre.Console;
using TurnBasedRPG.Classes;

namespace TurnBasedRPG
{
    internal static class Draw
    {
        private static string[] _availableChampions = new string[]
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
                var selected = SelectChampion(GetChoices(_availableChampions.ToList()));
                _selectedChampions.Add(selected);
            }

            return _selectedChampions;
        }

        private static string SelectChampion(string[] availableChoices)
            => AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select champions")
                .AddChoices(availableChoices));

        private static string[] GetChoices(List<string> current)
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
            table.AddRow(new string[] { "Rarity" }.Concat(items.Select(item => item.Rarity.ToString())).ToArray());
            AddStatRow("Health", StatTypes.Health, table, items);
            AddStatRow("Armor", StatTypes.Armor, table, items);
            AddStatRow("Magic Defense", StatTypes.MagicDefense, table, items);
            AddStatRow("Strength", StatTypes.Strength, table, items);
        }

        private static void AddStatRow(string category, StatTypes type, Table table, List<Item> items)
            => table.AddRow(new string[] { category }.Concat(items.Select(item => item.Stats[type].ToString())).ToArray());
            => current.Where(champion =>
                !_selectedChampions.Contains(champion))
                .ToArray();

        public static string SelectChampionTurn(List<string> champions)
            => AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Select champion")
                .AddChoices(champions));
    }
}
