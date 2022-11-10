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
