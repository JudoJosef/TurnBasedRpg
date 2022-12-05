using TurnBasedRPG.Dungeons.Enemies.Skills;

namespace TurnBasedRPG.Dungeons.Enemies
{
    public class MonsterFactory
    {
        public static List<IMonster> GetMonsters(int dungeonLevel)
        {
            var randomType = (EnemyTypes)new Random().Next(0, 10);
            return new List<IMonster>
            {
                GetMonster(randomType, dungeonLevel),
                GetMonster(randomType, dungeonLevel),
                GetMonster(randomType, dungeonLevel),
            };
        }

        public static Boss GetBoss(int dungeonLevel)
            => (EnemyTypes)new Random().Next(30, 35) switch
            {
                EnemyTypes.Amon => SummonAmon(dungeonLevel),
                EnemyTypes.DemonKing => SummonDemonKing(dungeonLevel),
                EnemyTypes.GhostSamurai => SummonGhostSamurai(dungeonLevel),
                EnemyTypes.Kasparov => SummonKasparov(dungeonLevel),
                EnemyTypes.SoulEater => SummonSoulEater(dungeonLevel),
                _ => throw new Exception(),
            };

        private static Monster GetMonster(EnemyTypes type, int dungeonLevel)
            => type switch
            {
                EnemyTypes.Cyclops => SummonCyclops(dungeonLevel),
                EnemyTypes.Giant => SummonGiant(dungeonLevel),
                EnemyTypes.Griffin => SummonGriffin(dungeonLevel),
                EnemyTypes.Goblin => SummonGoblin(dungeonLevel),
                EnemyTypes.Basilisk => SummonBasilisk(dungeonLevel),
                EnemyTypes.Wolfpack => SummonWolfpack(dungeonLevel),
                EnemyTypes.Dragon => SummonDragon(dungeonLevel),
                EnemyTypes.Tarantula => SummonTarantula(dungeonLevel),
                EnemyTypes.Skeleton => SummonSkeleton(dungeonLevel),
                EnemyTypes.Zombie => SummonZombie(dungeonLevel),
                _ => throw new Exception(),
            };

        private static Monster SummonCyclops(int dungeonLevel)
            => new Monster(
                (int)(200 * GetMultiplicator(dungeonLevel)),
                (int)(40 * GetMultiplicator(dungeonLevel)),
                (int)(40 * GetMultiplicator(dungeonLevel)),
                (int)(25 * GetMultiplicator(dungeonLevel)),
                CyclopsSkills.GetSkills(),
                (int)(5 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Cyclops);

        private static Monster SummonGiant(int dungeonLevel)
            => new Monster(
                (int)(250 * GetMultiplicator(dungeonLevel)),
                (int)(45 * GetMultiplicator(dungeonLevel)),
                (int)(45 * GetMultiplicator(dungeonLevel)),
                (int)(20 * GetMultiplicator(dungeonLevel)),
                GiantSkills.GetSkills(),
                (int)(7 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Giant);

        private static Monster SummonGriffin(int dungeonLevel)
            => new Monster(
                (int)(120 * GetMultiplicator(dungeonLevel)),
                (int)(30 * GetMultiplicator(dungeonLevel)),
                (int)(30 * GetMultiplicator(dungeonLevel)),
                (int)(55 * GetMultiplicator(dungeonLevel)),
                GriffinSkills.GetSkills(),
                (int)(7 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Griffin);

        private static Monster SummonGoblin(int dungeonLevel)
            => new Monster(
                (int)(90 * GetMultiplicator(dungeonLevel)),
                (int)(15 * GetMultiplicator(dungeonLevel)),
                (int)(15 * GetMultiplicator(dungeonLevel)),
                (int)(70 * GetMultiplicator(dungeonLevel)),
                GoblinSkills.GetSkills(),
                (int)(10 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Goblin);

        private static Monster SummonTarantula(int dungeonLevel)
            => new Monster(
                (int)(190 * GetMultiplicator(dungeonLevel)),
                (int)(35 * GetMultiplicator(dungeonLevel)),
                (int)(35 * GetMultiplicator(dungeonLevel)),
                (int)(65 * GetMultiplicator(dungeonLevel)),
                TarantulaSkills.GetSkills(),
                (int)(20 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Tarantula);

        private static Monster SummonDragon(int dungeonLevel)
            => new Monster(
                (int)(500 * GetMultiplicator(dungeonLevel)),
                (int)(70 * GetMultiplicator(dungeonLevel)),
                (int)(70 * GetMultiplicator(dungeonLevel)),
                (int)(70 * GetMultiplicator(dungeonLevel)),
                DragonSkills.GetSkills(),
                (int)(40 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Dragon);

        private static Monster SummonWolfpack(int dungeonLevel)
            => new Monster(
                (int)(140 * GetMultiplicator(dungeonLevel)),
                (int)(30 * GetMultiplicator(dungeonLevel)),
                (int)(30 * GetMultiplicator(dungeonLevel)),
                (int)(60 * GetMultiplicator(dungeonLevel)),
                WolfpackSkills.GetSkills(),
                (int)(19 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Wolfpack);

        private static Monster SummonSkeleton(int dungeonLevel)
            => new Monster(
                (int)(130 * GetMultiplicator(dungeonLevel)),
                (int)(5 * GetMultiplicator(dungeonLevel)),
                (int)(5 * GetMultiplicator(dungeonLevel)),
                (int)(120 * GetMultiplicator(dungeonLevel)),
                SkeletonSkills.GetSkills(),
                (int)(25 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Skeleton);

        private static Monster SummonZombie(int dungeonLevel)
            => new Monster(
                (int)(110 * GetMultiplicator(dungeonLevel)),
                (int)(30 * GetMultiplicator(dungeonLevel)),
                (int)(30 * GetMultiplicator(dungeonLevel)),
                (int)(35 * GetMultiplicator(dungeonLevel)),
                ZombieSkills.GetSkills(),
                (int)(15 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Zombie);

        private static Monster SummonBasilisk(int dungeonLevel)
            => new Monster(
                (int)(300 * GetMultiplicator(dungeonLevel)),
                (int)(50 * GetMultiplicator(dungeonLevel)),
                (int)(50 * GetMultiplicator(dungeonLevel)),
                (int)(65 * GetMultiplicator(dungeonLevel)),
                BasiliskSkills.GetSkills(),
                (int)(45 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Basilisk);

        private static Boss SummonAmon(int dungeonLevel)
            => new Boss(
                (int)(900 * GetMultiplicator(dungeonLevel)),
                200,
                150,
                (int)(100 * GetMultiplicator(dungeonLevel)),
                AmonSkills.GetSkills(),
                (int)(1000 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Amon);

        private static Boss SummonDemonKing(int dungeonLevel)
            => new Boss(
                (int)(1100 * GetMultiplicator(dungeonLevel)),
                210,
                230,
                (int)(280 * GetMultiplicator(dungeonLevel)),
                DemonKingSkills.GetSkills(),
                (int)(1000 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.DemonKing);

        private static Boss SummonGhostSamurai(int dungeonLevel)
            => new Boss(
                (int)(1800 * GetMultiplicator(dungeonLevel)),
                130,
                60,
                (int)(220 * GetMultiplicator(dungeonLevel)),
                GhostSamuraiSkills.GetSkills(),
                (int)(1000 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.GhostSamurai);

        private static Boss SummonKasparov(int dungeonLevel)
            => new Boss(
                (int)(1200 * GetMultiplicator(dungeonLevel)),
                250,
                250,
                (int)(15 * GetMultiplicator(dungeonLevel)),
                KasparovSkills.GetSkills(),
                (int)(1000 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.Kasparov);

        private static Boss SummonSoulEater(int dungeonLevel)
            => new Boss(
                (int)(3000 * GetMultiplicator(dungeonLevel)),
                150,
                150,
                (int)(120 * GetMultiplicator(dungeonLevel)),
                SoulEaterSkills.GetSkills(),
                (int)(1000 * GetMultiplicator(dungeonLevel)),
                EnemyTypes.SoulEater);

        private static double GetMultiplicator(int dungeonLevel)
            => ((double)dungeonLevel / 10) + 1;
    }
}
