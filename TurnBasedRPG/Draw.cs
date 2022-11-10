using TurnBasedRPG.Classes;
using TurnBasedRPG.Selection;

namespace TurnBasedRPG
{
    internal static class Draw
    {
        private static List<SelectionOption> _availableChampions = new List<SelectionOption>
        {
            new SelectionOption(ClassTypes.Archer, () => SelectChampion(ClassTypes.Archer)),
            new SelectionOption(ClassTypes.Assassin, () => SelectChampion(ClassTypes.Assassin)),
            new SelectionOption(ClassTypes.Dryad, () => SelectChampion(ClassTypes.Dryad)),
            new SelectionOption(ClassTypes.Fighter, () => SelectChampion(ClassTypes.Fighter)),
            new SelectionOption(ClassTypes.Jojo, () => SelectChampion(ClassTypes.Jojo)),
            new SelectionOption(ClassTypes.Mage, () => SelectChampion(ClassTypes.Mage)),
            new SelectionOption(ClassTypes.Paladin, () => SelectChampion(ClassTypes.Paladin)),
            new SelectionOption(ClassTypes.Swordsman, () => SelectChampion(ClassTypes.Swordsman)),
        };

        private static List<ClassTypes> _selectedChampions = new List<ClassTypes>();

        public static List<ClassTypes> SelectChampions()
        {
            OpenMenu(_availableChampions);

            return _selectedChampions;
        }

        public static Champion SelectChampionTurn(List<Champion> champions)
        {
            var options = new List<TurnOption>();
            champions.ForEach(champion => options.Add(new TurnOption(champion.Type, () => champion)));

            return OpenMenu(options);
        }

        private static void OpenMenu(List<SelectionOption> options)
        {
            var index = 0;
            ConsoleKeyInfo keyinfo;
            WriteMenu(options, options[index]);

            do
            {
                keyinfo = Console.ReadKey();

                index = CheckForNavigation(keyinfo, index, options);

                if (keyinfo.Key == ConsoleKey.Enter && !_selectedChampions.Contains(options[index].Name))
                {
                    options[index].Selected.Invoke();
                    index = 0;
                    WriteMenu(options, options[index]);
                }
            }
            while (_selectedChampions.Count < 3);
        }

        private static Champion OpenMenu(List<TurnOption> options)
        {
            var index = 0;
            ConsoleKeyInfo keyinfo;
            WriteMenu(options, options[index]);

            do
            {
                keyinfo = Console.ReadKey();

                index = CheckForNavigation(keyinfo, index, options);

                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    return options[index].Selected.Invoke();
                }
            }
            while (true);
        }

        private static int CheckForNavigation<T>(ConsoleKeyInfo keyInfo, int index, List<T> options)
            where T : IOption
        {
            if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                index = KeyInteraction(index, options, index + 1 < options.Count, 1);
            }

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                index = KeyInteraction(index, options, index - 1 >= 0, -1);
            }

            return index;
        }

        private static void WriteMenu<T>(List<T> options, T selectedOption)
            where T : IOption
        {
            Console.Clear();

            foreach (var option in options)
            {
                if (_selectedChampions.Contains(option.Name) && option.Name == selectedOption.Name)
                {
                    ChangeColorAndWriteEntry("> ", option.Name.ToString());
                }
                else if (_selectedChampions.Contains(option.Name))
                {
                    ChangeColorAndWriteEntry("  ", option.Name.ToString());
                }
                else if (option.Name == selectedOption.Name)
                {
                    WriteEntry("> ", option.Name.ToString());
                }
                else
                {
                    WriteEntry("  ", option.Name.ToString());
                }
            }
        }

        private static int KeyInteraction<T>(int index, List<T> options, bool condition, int diff)
            where T : IOption
        {
            if (condition)
            {
                index += diff;
                WriteMenu(options, options[index]);
            }

            return index;
        }

        private static void ChangeColorAndWriteEntry(string placeHolder, string optionName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            WriteEntry(placeHolder, optionName);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void WriteEntry(string placeHolder, string optionName)
        {
            Console.Write(placeHolder);
            Console.WriteLine(optionName);
        }

        private static void SelectChampion(ClassTypes selected)
            => _selectedChampions.Add(selected);
    }
}
