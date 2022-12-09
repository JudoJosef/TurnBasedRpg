using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG;

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
    public const string SelectOption = "Select";
    public const string ReviveOption = "Revive";
    public const string SummonOption = "Summon";
    public const string MonstersOption = "Monsters";
    public const string BossesOption = "Bosses";

    public const string ForgeOption = "Forge";
    public const string ShopOption = "Shop";
    public const string ChampionsOption = "Champions";
    public const string DungeonOption = "Dungeon";
    public const string AltarOption = "Altar";
    public const string BookOfMonstersOption = "Book of Monsters";
    public const string ExitOption = "Exit";

    public const string SelectOptionCaption = "Select option";
    public const string SelectTargetCaption = "Select target";
    public const string SelectActionCaption = "Select action";
    public const string SelectSkillCaption = "Select skill";
    public const string SelectAllyCaption = "Select ally";
    public const string SelectSacrificeCaption = "Select sacrifice";
    public const string SelectCategoryCaption = "Select category";
    public const string SelectMonsterCaption = "Select monster";
    public const string SelectBossCaption = "Select boss";
    public const string SelectChampionCaption = "Select champion";
    public const string SelectItemCaption = "Select item";
    public const string SelectItemTypeCaption = "Select item type";
    public const string SelectRarityCaption = "Select rarity";
    public const string SelectItemToUpgradeCaption = "Select item to upgrade";
    public const string ReturnToLobbyCaption = "Return to lobby or continue?";
    public const string EnterCodeCaption = "Enter code:";
    public const string EquippedItemsCaption = "Equipped items";
    public const string NotEnoughGoldCaption = "Not enough Gold";
    public const string NotEnoughMaterialsCaption = "Not enough Materials";
    public const string EnteredShopCaption = "You have entered the shop";

    public const string AttackOption = "Attack";
    public const string UseSkillOption = "Use skill";

    public const string ReturnToLobbyOption = "Return to Lobby";
    public const string ContinueOption = "Continue";

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
