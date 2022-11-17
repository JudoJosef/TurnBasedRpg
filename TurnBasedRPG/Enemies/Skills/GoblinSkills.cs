using TurnBasedRPG.Classes;

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
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
        }

        private static Skill GetFirstSkill()
            => new Skill("Jumpattack", 3, UseFirstSkill, Descriptions.Goblin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Steal", 10, UseSecondSkill, Descriptions.Goblin.SecondSkill);
    }
}
