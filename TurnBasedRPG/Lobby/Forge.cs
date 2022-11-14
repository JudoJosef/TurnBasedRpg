using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Lobby
{
    internal class Forge
    {
        public static void EnterForge(Summoner summoner)
        {
            string selected = string.Empty;

            while (selected != _backOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(new List<string> { _upgradeOption, _craftOption, _backOption }, "You have entered the forge.");
                if (selected == _upgradeOption)
                    Upgrade(summoner);
                else if (selected == _craftOption)
                    Craft(summoner.Inventory);
            }
        }
    }
}
