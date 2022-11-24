using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class GriffinSkills : IMonsterSkills
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
            var damage = (int)(monster.Strength * 1.9);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(monster, 0);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = (int)(monster.Strength * 2.2);
            targets.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(monster, 1);
            Draw.WriteLineAndWait(Messages.UseAOESkill(((IMonster)monster).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Grab", 4, UseFirstSkill, Descriptions.Griffin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Wingstorm", 6, UseSecondSkill, Descriptions.Griffin.SecondSkill);
    }
}
