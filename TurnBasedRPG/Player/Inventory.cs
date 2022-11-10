using TurnBasedRPG.Lobby.Items;

namespace TurnBasedRPG.Player
{
    internal class SummonerInventory
    {
        public SummonerInventory()
            => Loot = Enum.GetValues<LootTypes>().Select(type => new Loot(type, 0)).ToList();

        public List<Loot> Loot { get; set; }
        public Dictionary<int, Item> Items { get; set; } = new Dictionary<int, Item>();
        public int Gold { get; set; }
    }
}
