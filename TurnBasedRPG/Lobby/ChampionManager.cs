using TurnBasedRPG.Classes;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Lobby
{
    internal class ChampionManager
    {
        public static void ShowChampions(Summoner summoner)
        {
            var selected = string.Empty;

            while (selected != "Back")
            {
                selected = Draw.SelectSingle(
                    summoner.Champions.Select(champion => champion.Type.ToString())
                    .Concat(new List<string> { "Back" }),
                    "Select champion.");

                if (selected != "Back")
                    ShowChampion(GetChampion(summoner, selected));
            }
        }

        private static void ShowChampion(Champion champion)
        {
            var selected = string.Empty;

            while (selected != "Back")
            {
                Draw.Clear();
                Draw.WriteChampionStatTable(champion);
                selected = Draw.SelectSingle(new List<string> { "Items", "Abilities", "Back" },
                    "Select action.");

                if (selected == "Items")
                    ShowItems(champion);
                else if (selected == "Abilities")
                    ShowAbilities(champion);
            }
        }

        private static void ShowAbilities(Champion champion)
        {
            var selected = string.Empty;

            while (selected != "Back")
            {
                Draw.Clear();
                selected = Draw.SelectSingle(champion.Skills.Select(skill => skill.Name).Concat(new List<string> { "Back" }), "Select ability:");

                if (selected != "Back")
                    ShowDescrption(selected, champion);
            }
        }

        private static void ShowItems(Champion champion)
        {
            Draw.WriteItemTable(champion.Inventory.Items.Values.ToList());
            Draw.WriteLineAndWait(string.Empty);
        }

        private static void ShowDescrption(string selected, Champion champion)
        {
            var skill = champion.Skills.Where(skill => skill.Name == selected).First();

            Draw.WriteLineAndWait($"{skill.Name}\n{skill.Description}");
        }

        private static Champion GetChampion(Summoner summoner, string selected)
            => summoner.Champions.Where(champion => champion.Type == Enum.Parse<ClassTypes>(selected)).First();
    }
}
