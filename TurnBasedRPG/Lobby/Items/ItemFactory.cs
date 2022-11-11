using System.Globalization;

namespace TurnBasedRPG.Lobby.Items
{
    internal class ItemFactory
    {
        public static Item GetItem(int dungeonLevel)
            => GetItem(GetRarity(new Random().Next(1, 101), dungeonLevel), GetTypeAndName());

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

            return (GetName(type, new Random().Next(1, 4)), type);
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

        private static List<Stats> GetStats(ItemRarity rarity)
            => new List<Stats>
            {
                new Stats(StatTypes.Health, GetValueToRarity(rarity, StatValues.HealthStats)),
                new Stats(StatTypes.PhysicDefense, GetValueToRarity(rarity, StatValues.PhysicalDefenseStats)),
                new Stats(StatTypes.MagicDefense, GetValueToRarity(rarity, StatValues.MagicDefenseStats)),
                new Stats(StatTypes.Strength, GetValueToRarity(rarity, StatValues.StrengthStats)),
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
