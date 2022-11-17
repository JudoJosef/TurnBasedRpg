namespace TurnBasedRPG.Enemies.Skills
{
    internal class GriffinSkills : IMonsterSkills
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
            => new Skill("Grab", 4, UseFirstSkill, Descriptions.Griffin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Wingstorm", 6, UseSecondSkill, Descriptions.Griffin.SecondSkill);
    }
}
