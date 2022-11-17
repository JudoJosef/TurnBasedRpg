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
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
        }

        private static Skill GetFirstSkill()
            => new Skill("Smash", 5, UseFirstSkill, Descriptions.Giant.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Jump", 8, UseSecondSkill, Descriptions.Giant.SecondSkill);
    }
}
