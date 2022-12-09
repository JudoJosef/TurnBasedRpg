using TurnBasedRPG.Champions;
using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;
using TurnBasedRPG.Lobby;
using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Database;

public class DatabaseDetails
{
    public const string SummonerTableName = nameof(Summoner);
    public const string ChampionTableName = nameof(Champion);
    public const string SummonerInventoryTableName = nameof(SummonerInventory);
    public const string ItemTableName = nameof(Item);
    public const string BookOfMonstersTableName = nameof(BookOfMonsters);
    public const string StatsTableName = "Stats";

    public const string DungeonLevelColumn = nameof(Dungeon.DungeonLevel);

    public const string ExperienceColumn = nameof(Champion.Experience);
    public const string NeededExperienceColumn = nameof(Champion.NeededExperience);
    public const string HelmetColumn = nameof(ItemTypes.Helmet);
    public const string ChestplateColumn = nameof(ItemTypes.Chestplate);
    public const string LegginsColumn = nameof(ItemTypes.Leggins);
    public const string BootsColumn = nameof(ItemTypes.Boots);
    public const string WeaponColumn = nameof(ItemTypes.Weapon);
    public const string AccessoireColumn = nameof(ItemTypes.Accessoire);
    public const string LevelColumn = nameof(Champion.Level);
    public const string ClassTypeColumn = nameof(ClassTypes);

    public const string HealthColumn = nameof(Champion.Health);
    public const string MaxHealthColumn = nameof(Champion.MaxHealth);
    public const string ShieldColumn = nameof(Champion.Shield);
    public const string ArmorColumn = nameof(Champion.Armor);
    public const string MagicDefenseColumn = nameof(Champion.MagicDefense);
    public const string StrengthColumn = nameof(Champion.Strength);

    public const string RarityColumn = nameof(ItemRarity);
    public const string ItemTypeColumn = nameof(ItemTypes);
    public const string PriceColumn = nameof(Item.Price);
    public const string NameColumn = nameof(Item.Name);

    public const string GoldColumn = nameof(SummonerInventory.Gold);
    public const string LeatherColumn = nameof(LootTypes.Leather);
    public const string ScalesColumn = nameof(LootTypes.Scales);
    public const string OrcTeethColumn = nameof(LootTypes.Orcteeth);
    public const string ScrapColumn = nameof(LootTypes.Scrap);
    public const string SilkColumn = nameof(LootTypes.Silk);

    public const string WolfpackColumn = nameof(EnemyTypes.Wolfpack);
    public const string GoblinColumn = nameof(EnemyTypes.Goblin);
    public const string SkeletonColumn = nameof(EnemyTypes.Skeleton);
    public const string ZombieColumn = nameof(EnemyTypes.Zombie);
    public const string BasiliskColumn = nameof(EnemyTypes.Basilisk);
    public const string GiantColumn = nameof(EnemyTypes.Giant);
    public const string GriffinColumn = nameof(EnemyTypes.Griffin);
    public const string DragonColumn = nameof(EnemyTypes.Dragon);
    public const string CyclopsColumn = nameof(EnemyTypes.Cyclops);
    public const string TarantulaColumn = nameof(EnemyTypes.Tarantula);
    public const string GhostSamuraiColumn = nameof(EnemyTypes.GhostSamurai);
    public const string KasparovColumn = nameof(EnemyTypes.Kasparov);
    public const string DemonKingColumn = nameof(EnemyTypes.DemonKing);
    public const string SoulEaterColumn = nameof(EnemyTypes.SoulEater);
    public const string AmonColumn = nameof(EnemyTypes.Amon);
}
