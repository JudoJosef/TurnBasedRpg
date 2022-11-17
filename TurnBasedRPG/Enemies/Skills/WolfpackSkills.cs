namespace TurnBasedRPG.Enemies.Skills
{
    internal class WolfpackSkills : IMonsterSkills
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
            => new Skill("On the hunt", 4, UseFirstSkill, Descriptions.Wolfpack.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Howl", 8, UseSecondSkill, Descriptions.Wolfpack.SecondSkill);
    }
}
