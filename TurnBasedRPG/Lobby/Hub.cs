using TurnBasedRPG.Player;
using TurnBasedRPG.Dungeons;
using static TurnBasedRPG.Lobby.Constants;

namespace TurnBasedRPG.Lobby
{
    public class Hub
    {
        private readonly Summoner _summoner;
        private readonly Forge _forge;
        private readonly Shop _shop;
        private readonly ChampionInspector _inspector;
        private readonly Dungeon _dungeon;
        private readonly Altar _altar;

        public Hub(Summoner summoner, ChampionInspector inspector)
        {
            _summoner = summoner;
            _forge = new Forge(_summoner);
            _shop = new Shop(_summoner);
            _inspector = inspector;
            _inspector.SetManager(new ChampionManager(_summoner));
            _dungeon = new Dungeon(_summoner);
            _altar = new Altar(_summoner);
        }

        public void EnterLobby()
        {
            while (true)
            {
                Draw.Clear();
                var selected = Draw.SelectSingle(new List<string> { ForgeOption, ShopOption, ChampionsOption, "Altar", DungeonOption, ExitOption }, "Select option");
                Execute(selected);
            }
        }

        private void Execute(string selected)
        {
            switch (selected)
            {
                case ForgeOption:
                    _forge.EnterForge();
                    break;
                case ShopOption:
                    _shop.OpenShop(_dungeon.DungeonLevel);
                    break;
                case ChampionsOption:
                    _inspector.ShowChampions(_summoner.Champions, new List<string> { ItemsOption, AbilitiesOption, BackOption });
                    break;
                case DungeonOption:
                    _dungeon.EnterDungeon();
                    break;
                case "Altar":
                    _altar.Open();
                    break;
                case ExitOption:
                    Environment.Exit(0);
                    break;
            };
        }
    }
}
