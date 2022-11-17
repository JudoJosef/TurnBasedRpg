namespace TurnBasedRPG.Enemies.Skills
{
    internal class DragonSkills : IMonsterSkills
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
            => new Skill("Fiery breath", 5, UseFirstSkill, Descriptions.Dragon.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Magma stream", 10, UseSecondSkill, Descriptions.Dragon.SecondSkill);
    }
}
