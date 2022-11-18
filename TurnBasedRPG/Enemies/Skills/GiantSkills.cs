using TurnBasedRPG.Dungeons;

namespace TurnBasedRPG.Enemies.Skills
{
    internal class GiantSkills : IMonsterSkills
    {
        public static IEnumerable<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
            };

        public static void UseFirstSkill(ICreature monster, List<ICreature> targets)
        {
            var target = GameHandler.GetRandomTarget(targets);
            var damage = (int)(monster.Strength * 2.5);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(monster, 0);
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = monster.Strength * 5;
            targets.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(monster, 1);
        }

        private static Skill GetFirstSkill()
            => new Skill("Smash", 5, UseFirstSkill, Descriptions.Giant.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Jump", 8, UseSecondSkill, Descriptions.Giant.SecondSkill);
    }
}
