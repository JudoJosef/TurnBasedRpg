using System.Globalization;

namespace TurnBasedRPG.Lobby.Items
{
    public class ItemFactory
    {
        public static Item GetItem(int dungeonLevel)
            => GetItem(GetRarity(new Random().Next(1, 101), dungeonLevel), GetTypeAndName());

        public static Item GetItem(ItemRarity rarity)
            => GetItem(rarity, GetTypeAndName());

        private static Item GetItem(ItemRarity rarity, (Enum name, ItemTypes type) misc)
            => new Item(misc.type, misc.name, rarity, GetValueToRarity(rarity, StatValues.Prices), GetStats(rarity));

        private static ItemRarity GetRarity(int index, int dungeonLevel)
            => index <= dungeonLevel
                ? ItemRarity.Mythic
                : index <= dungeonLevel * 1.5
                    ? ItemRarity.Legendary
                    : index <= dungeonLevel * 2
                        ? ItemRarity.Epic
                        : (ItemRarity)new Random().Next(0, 3);

        private static (Enum name, ItemTypes type) GetTypeAndName()
        {
            var type = (ItemTypes)new Random().Next(0, 6);

            return (GetName(type, new Random().Next(0, 3)), type);
        }

        private static Enum GetName(ItemTypes type, int index)
            => type switch
            {
                ItemTypes.Helmet => (HelmetNames)index,
                ItemTypes.Chestplate => (ChestplateNames)index,
                ItemTypes.Leggins => (LegginsNames)index,
                ItemTypes.Boots => (BootNames)index,
                ItemTypes.Weapon => (WeaponNames)index,
                ItemTypes.Accessoire => (AccessoireNames)index,
                _ => throw new CultureNotFoundException()
            };

        private static Dictionary<StatTypes, int> GetStats(ItemRarity rarity)
            => new Dictionary<StatTypes, int>
            {
                { StatTypes.Health, GetValueToRarity(rarity, StatValues.HealthStats) },
                { StatTypes.Armor, GetValueToRarity(rarity, StatValues.ArmorStats) },
                { StatTypes.MagicDefense, GetValueToRarity(rarity, StatValues.MagicDefenseStats) },
                { StatTypes.Strength, GetValueToRarity(rarity, StatValues.StrengthStats) },
            };

        private static int GetValueToRarity(ItemRarity rarity, Func<int>[] values)
            => rarity switch
            {
                ItemRarity.Common => values[0](),
                ItemRarity.Uncommon => values[1](),
                ItemRarity.Rare => values[2](),
                ItemRarity.Epic => values[3](),
                ItemRarity.Legendary => values[4](),
                ItemRarity.Mythic => values[5](),
                _ => throw new CultureNotFoundException()
            };
    }
}
