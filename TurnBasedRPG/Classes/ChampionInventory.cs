using TurnBasedRPG.Lobby.Items;

namespace TurnBasedRPG.Classes
{
    internal class ChampionInventory
    {
        public Dictionary<ItemTypes, Item> Items { get; set; } = new Dictionary<ItemTypes, Item>();
    }
}
