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
        private readonly ChampionManager _manager;
        private readonly Dungeon _dungeon;

        public Hub(Summoner summoner)
        {
            _summoner = summoner;
            _forge = new Forge(_summoner);
            _shop = new Shop(_summoner);
            _manager = new ChampionManager(_summoner);
            _dungeon = new Dungeon(_summoner);
        }

        public void EnterLobby()
        {
            while (true)
            {
                Draw.Clear();
                var selected = Draw.SelectSingle(new List<string> { ForgeOption, ShopOption, ChampionsOption, DungeonOption, ExitOption }, "Select option");
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
                    _shop.OpenShop(1);
                    break;
                case ChampionsOption:
                    _manager.ShowChampions();
                    break;
                case DungeonOption:
                    _dungeon.EnterDungeon();
                    break;
                case ExitOption:
                    Environment.Exit(0);
                    break;
            };
        }
    }
}
