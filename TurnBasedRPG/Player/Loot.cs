namespace TurnBasedRPG.Player
{
    internal enum LootTypes
    {
        Leather,
        Scales,
        Orcteeth,
        Scrap,
        Silk
    }

    internal class Loot
    {
        public Loot(LootTypes type, int amount)
        {
            Type = type;
            Amount = amount;
        }

        public LootTypes Type { get; }
        public int Amount { get; }
    }
}
