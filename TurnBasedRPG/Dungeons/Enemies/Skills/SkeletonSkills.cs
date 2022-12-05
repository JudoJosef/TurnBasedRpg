using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class SkeletonSkills : IMonsterSkills
    {
        public static List<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
            };

        public static void UseFirstSkill(ICreature monster, List<ICreature> targets)
        {
            var target = GameHandler.GetRandomTarget(targets);
            var damage = monster.Strength * 2;
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(monster, 0);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var target = GameHandler.GetRandomTarget(targets);
            var damage = monster.Strength * 2;
            var rounds = 3;
            GameHandler.AddDebuff(target, damage, rounds);
            GameHandler.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.DebuffTarget(((IMonster)monster).Type, ((IAlly)target).Type, rounds));
        }

        private static Skill GetFirstSkill()
            => new Skill("Bone throw", 3, UseFirstSkill, Descriptions.Skeleton.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Skeletal curse", 7, UseSecondSkill, Descriptions.Skeleton.SecondSkill);
    }
}
