using TurnBasedRPG.Classes;
using TurnBasedRPG.Dungeons;

namespace TurnBasedRPG.Enemies.Skills
{
    internal class GoblinSkills : IMonsterSkills
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
            var damage = (int)(monster.Strength * 1.5);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(monster, 0);
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var target = GameHandler.GetRandomTarget(targets);
            GameHandler.StealItem(target);
            GameHandler.SetCooldown(monster, 1);
        }

        private static Skill GetFirstSkill()
            => new Skill("Jumpattack", 3, UseFirstSkill, Descriptions.Goblin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Steal", 10, UseSecondSkill, Descriptions.Goblin.SecondSkill);
    }
}
