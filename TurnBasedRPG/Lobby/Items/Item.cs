using System.Text.RegularExpressions;

namespace TurnBasedRPG.Lobby.Items
{
    internal class Item
    {
        public Item(ItemTypes type, Enum name, ItemRarity rarity, int price, Dictionary<StatTypes, int> stats)
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
        public Dictionary<StatTypes, int> Stats { get; }
    }

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