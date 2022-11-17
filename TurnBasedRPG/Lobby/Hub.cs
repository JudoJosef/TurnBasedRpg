using TurnBasedRPG.Player;
using TurnBasedRPG.Dungeons;

namespace TurnBasedRPG.Lobby
{
    public class Hub
    {
        private readonly Summoner _summoner;
        private readonly Forge _forge;
        private readonly Shop _shop;
        private readonly ChampionManager _manager;
        private readonly Dungeon _dungeon;

        public Hub(Summoner summoner)
        {
            _summoner = summoner;
        }

        public void EnterLobby()
        {
            var selected = string.Empty;

            while (true)
            {
                selected = Draw.SelectSingle(new List<string> { "Forge", "Shop", "Dungeon", "Exit" }, "Select option");
                Execute(selected);
            }
        }

        private void Execute(string selected)
        {
            switch (selected)
            {
                case "Forge":
                    Forge.EnterForge(_summoner);
                    break;
                case "Shop":
                    Shop.OpenShop(_summoner.Inventory, 1);
                    break;
                case "Dungeon":
                    throw new NotImplementedException();
                case "Exit":
                    Environment.Exit(0);
                    break;
            };
        }
    }
}
