namespace TurnBasedRPG.Enemies.Skills
{
    internal class BasiliskSkills : IMonsterSkills
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
            => new Skill("Acid breath", 6, UseFirstSkill, Descriptions.Basilisk.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Stone eyes", 13, UseSecondSkill, Descriptions.Basilisk.SecondSkill);
    }
}
