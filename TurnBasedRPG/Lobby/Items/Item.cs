using System.Text.RegularExpressions;

namespace TurnBasedRPG.Lobby.Items
{
    public class Item
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
        public int Level { get; set; } = 1;
        public string Name { get; }
        public ItemRarity Rarity { get; }
        public int Price { get; }
        public Dictionary<StatTypes, int> Stats { get; set; }

        public void Upgrade()
        {
            Level++;

            Stats = new Dictionary<StatTypes, int>()
            {
                { StatTypes.Health, (int)Math.Ceiling(Stats[StatTypes.Health] * 1.2) },
                { StatTypes.Armor, (int)Math.Ceiling(Stats[StatTypes.Armor] * 1.2) },
                { StatTypes.MagicDefense, (int)Math.Ceiling(Stats[StatTypes.MagicDefense] * 1.2) },
                { StatTypes.Strength, (int)Math.Ceiling(Stats[StatTypes.Strength] * 1.2) }
            };
        }
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