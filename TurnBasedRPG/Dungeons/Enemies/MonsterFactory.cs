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
                200 * dungeonLevel,
                40 * dungeonLevel,
                40 * dungeonLevel,
                25 * dungeonLevel,
                CyclopsSkills.GetSkills(),
                5 * dungeonLevel,
                EnemyTypes.Cyclops);

        private static Monster SummonGiant(int dungeonLevel)
            => new Monster(
                250 * dungeonLevel,
                45 * dungeonLevel,
                45 * dungeonLevel,
                20 * dungeonLevel,
                GiantSkills.GetSkills(),
                7 * dungeonLevel,
                EnemyTypes.Giant);

        private static Monster SummonGriffin(int dungeonLevel)
            => new Monster(
                120 * dungeonLevel,
                30 * dungeonLevel,
                30 * dungeonLevel,
                55 * dungeonLevel,
                GriffinSkills.GetSkills(),
                7 * dungeonLevel,
                EnemyTypes.Griffin);

        private static Monster SummonGoblin(int dungeonLevel)
            => new Monster(
                90 * dungeonLevel,
                15 * dungeonLevel,
                15 * dungeonLevel,
                70 * dungeonLevel,
                GoblinSkills.GetSkills(),
                10 * dungeonLevel,
                EnemyTypes.Goblin);

        private static Monster SummonTarantula(int dungeonLevel)
            => new Monster(
                190 * dungeonLevel,
                35 * dungeonLevel,
                35 * dungeonLevel,
                65 * dungeonLevel,
                TarantulaSkills.GetSkills(),
                20 * dungeonLevel,
                EnemyTypes.Tarantula);

        private static Monster SummonDragon(int dungeonLevel)
            => new Monster(
                500 * dungeonLevel,
                70 * dungeonLevel,
                70 * dungeonLevel,
                70 * dungeonLevel,
                DragonSkills.GetSkills(),
                40 * dungeonLevel,
                EnemyTypes.Dragon);

        private static Monster SummonWolfpack(int dungeonLevel)
            => new Monster(
                140 * dungeonLevel,
                30 * dungeonLevel,
                30 * dungeonLevel,
                60 * dungeonLevel,
                WolfpackSkills.GetSkills(),
                19 * dungeonLevel,
                EnemyTypes.Wolfpack);

        private static Monster SummonSkeleton(int dungeonLevel)
            => new Monster(
                130 * dungeonLevel,
                5 * dungeonLevel,
                5 * dungeonLevel,
                120 * dungeonLevel,
                SkeletonSkills.GetSkills(),
                25 * dungeonLevel,
                EnemyTypes.Skeleton);

        private static Monster SummonZombie(int dungeonLevel)
            => new Monster(
                110 * dungeonLevel,
                30 * dungeonLevel,
                30 * dungeonLevel,
                35 * dungeonLevel,
                ZombieSkills.GetSkills(),
                15 * dungeonLevel,
                EnemyTypes.Zombie);

        private static Monster SummonBasilisk(int dungeonLevel)
            => new Monster(
                300 * dungeonLevel,
                50 * dungeonLevel,
                50 * dungeonLevel,
                65 * dungeonLevel,
                BasiliskSkills.GetSkills(),
                45 * dungeonLevel,
                EnemyTypes.Basilisk);
    }
}
