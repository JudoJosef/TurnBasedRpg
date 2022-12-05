using static TurnBasedRPG.Database.DatabaseDetails;
using static TurnBasedRPG.Database.TypeTranslator;

namespace TurnBasedRPG.Database
{
    internal class DatamodelAssembler
    {
        internal record ColumnDetails(string TableName, string Name, string Type);

        internal static List<ColumnDetails> AssembleSummonerDatamodel()
            => new List<ColumnDetails>
            {
                new ColumnDetails(SummonerTableName, SummonerInventoryTableName, AllTypes[typeof(long)]),
                new ColumnDetails(SummonerTableName, DungeonLevelColumn, AllTypes[typeof(long)]),
                new ColumnDetails(SummonerTableName, BookOfMonstersTableName, AllTypes[typeof(long)]),
            };

        internal static List<ColumnDetails> AssembleChampionDatamodel()
            => new List<ColumnDetails>
            {
                new ColumnDetails(ChampionTableName, ExperienceColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, NeededExperienceColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, HelmetColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, ChestPlateColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, LegginsColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, BootsColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, WeaponColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, AccessoireColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, StatsTableName, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, LevelColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, ShieldColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, MaxHealthColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, ClassTypeColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ChampionTableName, SummonerTableName, AllTypes[typeof(long)]),
            };

        internal static List<ColumnDetails> AssembleItemDatamodel()
            => new List<ColumnDetails>
            {
                new ColumnDetails(ItemTableName, RarityColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ItemTableName, LevelColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ItemTableName, ItemTypeColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ItemTableName, StatsTableName, AllTypes[typeof(long)]),
                new ColumnDetails(ItemTableName, PriceColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ItemTableName, NameColumn, AllTypes[typeof(long)]),
                new ColumnDetails(ItemTableName, SummonerInventoryTableName, AllTypes[typeof(long)]),
            };

        internal static List<ColumnDetails> AssembleStatsDatamodel()
            => new List<ColumnDetails>
            {
                new ColumnDetails(StatsTableName, HealthColumn, AllTypes[typeof(long)]),
                new ColumnDetails(StatsTableName, ArmorColumn, AllTypes[typeof(long)]),
                new ColumnDetails(StatsTableName, MagicDefenseColumn, AllTypes[typeof(long)]),
                new ColumnDetails(StatsTableName, StrengthColumn, AllTypes[typeof(long)]),
            };

        internal static List<ColumnDetails> AssembleInventoryDatamodel()
            => new List<ColumnDetails>
            {
                new ColumnDetails(SummonerInventoryTableName, GoldColumn, AllTypes[typeof(long)]),
                new ColumnDetails(SummonerInventoryTableName, LeatherColumn, AllTypes[typeof(long)]),
                new ColumnDetails(SummonerInventoryTableName, ScalesColumn, AllTypes[typeof(long)]),
                new ColumnDetails(SummonerInventoryTableName, OrcTeethColumn, AllTypes[typeof(long)]),
                new ColumnDetails(SummonerInventoryTableName, ScrapColumn, AllTypes[typeof(long)]),
                new ColumnDetails(SummonerInventoryTableName, SilkColumn, AllTypes[typeof(long)]),
            };

        internal static List<ColumnDetails> AssembleBookOfMonstersDatamodel()
            => new List<ColumnDetails>
            {
                new ColumnDetails(BookOfMonstersTableName, WolfpackColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, GoblinColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, SkeletonColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, ZombieColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, BasiliskColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, GiantColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, GriffinColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, DragonColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, CyclopsColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, TarantulaColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, GhostSamuraiColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, KasparovColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, DemonKingColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, SoulEaterColumn, AllTypes[typeof(bool)]),
                new ColumnDetails(BookOfMonstersTableName, AmonColumn, AllTypes[typeof(bool)]),
            };
    }
}
