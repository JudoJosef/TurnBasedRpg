using TurnBasedRPG.Player;
using static TurnBasedRPG.Lobby.Constants;

namespace TurnBasedRPG.Lobby
{
    public class Altar
    {
        private Summoner _summoner;

        public Altar(Summoner summoner)
        {
            _summoner = summoner;
        }

        public void Open()
        {
            var selected = string.Empty;

            while (selected != BackOption)
            {
                selected = Draw.SelectSingle(new List<string> { "Revive", BackOption }, "Select option");

                if (selected != BackOption)
                    ShowDeadChampions();
            }
        }

        private void ShowDeadChampions()
        {
            var selected = string.Empty;

            while (selected != BackOption)
            {
                var cost = _summoner.Champions.First().Level * 50;
                selected = Draw.SelectSingle(
                    _summoner.Champions.Where(champion => champion.Health == 0)
                    .Select(champion =>
                        champion.Type.ToString())
                    .Concat(new List<string> { BackOption }),
                    $"Choose champion to revive ({_summoner.Inventory.Gold}/{cost} Gold)");

                if (selected != BackOption && _summoner.Inventory.Gold >= cost)
                    ReviveChampion(selected, cost);
                else if (selected != BackOption)
                    Draw.WriteLineAndWait("Not enough Gold");
            }
        }

        private void ReviveChampion(string selected, int cost)
        {
            var champion = _summoner.Champions.Where(champion => champion.Type.ToString() == selected).Single();
            _summoner.Inventory.Gold -= cost;
            champion.Health = champion.MaxHealth;

            Draw.WriteLineAndWait($"{selected} has been revived");
        }
    }
}
