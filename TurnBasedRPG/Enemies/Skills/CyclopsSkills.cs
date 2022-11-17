namespace TurnBasedRPG.Enemies.Skills
{
    internal class CyclopsSkills : IMonsterSkills
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
            => new Skill("Club masher", 3, UseFirstSkill, Descriptions.Cyclops.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Summon sheeps", 11, UseSecondSkill, Descriptions.Cyclops.SecondSkill);
    }
}
