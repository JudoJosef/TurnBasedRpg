using TurnBasedRPG.Lobby.Items;

namespace TurnBasedRPG.Champions
{
    public class ChampionInventory
    {
        public Dictionary<ItemTypes, Item> Items { get; set; } = new Dictionary<ItemTypes, Item>();
    }
}
