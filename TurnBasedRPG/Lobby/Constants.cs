using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Lobby
{
    public class Constants
    {
        public const string BackOption = "Back";
        public const string CraftOption = "Craft";
        public const string UpgradeOption = "Upgrade";
        public const string BuyOption = "Buy";
        public const string SellOption = "Sell";
        public const string RefreshOption = "Refresh (100)";
        public const string ItemsOption = "Items";
        public const string EquipOption = "Equip";
        public const string AbilitiesOption = "Abilities";

        public const string ForgeOption = "Forge";
        public const string ShopOption = "Shop";
        public const string ChampionsOption = "Champions";
        public const string DungeonOption = "Dungeon";
        public const string ExitOption = "Exit";

        public static readonly List<LootTypes> AllLootTypes = new List<LootTypes>
        {
            LootTypes.Leather,
            LootTypes.Scales,
            LootTypes.Orcteeth,
            LootTypes.Scrap,
            LootTypes.Silk,
        };
        public static readonly List<string> AllRarities = new List<string>
        {
            ItemRarity.Common.ToString(),
            ItemRarity.Uncommon.ToString(),
            ItemRarity.Rare.ToString(),
            ItemRarity.Epic.ToString(),
            ItemRarity.Legendary.ToString(),
            ItemRarity.Mythic.ToString(),
        };
        public static readonly IEnumerable<string> AllItemTypes = new List<string>
        {
            ItemTypes.Helmet.ToString(),
            ItemTypes.Chestplate.ToString(),
            ItemTypes.Leggins.ToString(),
            ItemTypes.Boots.ToString(),
            ItemTypes.Weapon.ToString(),
            ItemTypes.Accessoire.ToString(),
        };
    }
}
