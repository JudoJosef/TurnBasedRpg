namespace TurnBasedRPG.Enemies.Skills
{
    internal class TarantulaSkills : IMonsterSkills
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
            => new Skill("Venomous bite", 4, UseFirstSkill, Descriptions.Tarantula.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Webshot", 7, UseSecondSkill, Descriptions.Tarantula.SecondSkill);
    }
}
