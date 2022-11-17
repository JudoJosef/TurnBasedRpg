using TurnBasedRPG.Lobby.Items;

namespace TurnBasedRPG.Player
{
    public class SummonerInventory
    {
        public Dictionary<LootTypes, LootAmount> Loot { get; set; } = new Dictionary<LootTypes, LootAmount>
        {
            { LootTypes.Leather, new LootAmount() },
            { LootTypes.Scales, new LootAmount() },
            { LootTypes.Orcteeth, new LootAmount() },
            { LootTypes.Scrap, new LootAmount() },
            { LootTypes.Silk, new LootAmount() }
        };
        public Dictionary<int, Item> Items { get; set; } = new Dictionary<int, Item>();
        public int Gold { get; set; }
    }
}
