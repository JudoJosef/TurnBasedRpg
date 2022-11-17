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
        private static Champion GetChampion(Summoner summoner, string selected)
            => summoner.Champions.Where(champion => champion.Type == Enum.Parse<ClassTypes>(selected)).First();
    }
}
