using System.Text.RegularExpressions;

namespace TurnBasedRPG.Lobby.Items
{
    internal class Item
    {
        public Item(ItemTypes type, Enum name, ItemRarity rarity, int price, List<Stats> stats)
        {
            Type = type;
            Name = Regex.Replace(name.ToString(), "([a-z])([A-Z])", "$1 $2");
            Rarity = rarity;
            Price = price;
            Stats = stats;
        }

        public ItemTypes Type { get; }
        public string Name { get; }
        public ItemRarity Rarity { get; }
        public int Price { get; }
        public List<Stats> Stats { get; }
    }

    internal record Stats(StatTypes Type, int Value);

    public enum ItemTypes
    {
        Helmet,
        Chestplate,
        Leggins,
        Boots,
        Weapon,
        Accessoire
    }

    public enum ItemRarity
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Mythic
    }

    public enum StatTypes
    {
        Health,
        Armor,
        MagicDefense,
        Strength
    }
}