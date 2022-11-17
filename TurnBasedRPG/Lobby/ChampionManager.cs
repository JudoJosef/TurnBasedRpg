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
    }
}
