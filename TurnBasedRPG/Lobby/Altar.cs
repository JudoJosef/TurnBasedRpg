using TurnBasedRPG.Classes;
using TurnBasedRPG.Player;
using static TurnBasedRPG.Constants;

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
                UiReferencer.Clear();
                selected = UiReferencer.SelectSingle(new List<string> { "Revive", "Summon", BackOption }, "Select option");

                if (selected == "Revive")
                    ShowDeadChampions();
                else if (selected == "Summon")
                    SummonChampion();
            }
        }

        private void ShowDeadChampions()
        {
            var selected = string.Empty;

            while (selected != BackOption)
            {
                var cost = _summoner.Champions.First().Level * 50;
                selected = UiReferencer.SelectSingle(
                    _summoner.Champions.Where(champion => champion.Health == 0)
                    .Select(champion =>
                        champion.Type.ToString())
                    .Concat(new List<string> { BackOption }),
                    $"Choose champion to revive ({_summoner.Inventory.Gold}/{cost} Gold)");

                if (selected != BackOption && _summoner.Inventory.Gold >= cost)
                    ReviveChampion(selected, cost);
                else if (selected != BackOption)
                    UiReferencer.WriteLineAndWait("Not enough Gold");
            }
        }

        private void SummonChampion()
        {
            UiReferencer.Clear();
            var input = UiReferencer.GetLine("Enter code").ToLower();

            if (input == "jojo" &&
                !_summoner.Champions.Where(champion =>
                    champion.Type.ToString()
                    .ToLower() == input)
                .Any())
                AskForSacrifice();
            else if (input == "jojo")
                UiReferencer.WriteLineAndWait("Jojo has already been called");
            else if (input != BackOption)
                UiReferencer.WriteLineAndWait("Wrong code");
        }

        private void AskForSacrifice()
        {
            var selected = string.Empty;

            while (selected != BackOption)
            {
                selected = UiReferencer.SelectSingle(
                    _summoner.Champions.Select(champion =>
                        champion.Type.ToString())
                    .Concat(new List<string> { BackOption }),
                    "Select sacrifice");

                if (selected != BackOption)
                {
                    SummonChampion(selected);
                    break;
                }
            }
        }

        private void SummonChampion(string sacrifice)
        {
            var sacrificedChampion = _summoner.Champions.Where(champion => champion.Type.ToString() == sacrifice).Single();
            _summoner.Champions.Remove(sacrificedChampion);

            _summoner.Champions.Add(Portal.CallJojo());
            UiReferencer.WriteLineAndWait("Jojo has been called");
        }

        private void ReviveChampion(string selected, int cost)
        {
            var champion = _summoner.Champions.Where(champion => champion.Type.ToString() == selected).Single();
            _summoner.Inventory.Gold -= cost;
            champion.Health = champion.MaxHealth;

            UiReferencer.WriteLineAndWait($"{selected} has been revived");
        }
    }
}
