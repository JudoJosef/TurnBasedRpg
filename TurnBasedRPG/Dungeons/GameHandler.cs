using TurnBasedRPG.Classes;
using TurnBasedRPG.Enemies;

namespace TurnBasedRPG.Dungeons
{
    public class GameHandler
    {
        public static ICreature GetTarget(List<ICreature> creatures)
        {
            var target = Draw.SelectSingle(creatures.Select(creature => ((Monster)creature).Type.ToString()), "Select target");
            return creatures.Where(creature => ((Monster)creature).Type == Enum.Parse<EnemyTypes>(target)).First();
        }

        public static void DealPhysicalDamage(ICreature target, int damage)
            => target.Health -= GetReducedDamage(target.Armor, damage);

        public static void DealMagicDamage(ICreature target, int damage)
            => target.Health -= GetReducedDamage(target.MagicDefense, damage);

        public static void GiveShield(List<ICreature> recievers, int amount)
            => recievers.ForEach(reciever => ((Champion)reciever).Shield += amount);

        public static void GiveArmor(List<ICreature> recievers, int amount)
            => recievers.ForEach(reciever => ((Champion)reciever).Armor += amount);

        public static void AddDebuffs(List<ICreature> targets, int damage, int rounds)
            => targets.ForEach(target => AddDebuff(target, damage, rounds));

        public static void AddDebuff(ICreature target, int damage, int rounds)
            => target.Debuffs.Add(new Debuff(rounds, 
                target =>
                {
                    DealMagicDamage(target, damage);
                    rounds--;
                }));

        private static int GetReducedDamage(int armor, int damage)
            => damage / (1 + (armor / 100));
    }
}
