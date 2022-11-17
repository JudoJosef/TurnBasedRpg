namespace TurnBasedRPG.Enemies.Skills
{
    internal class ZombieSkills : IMonsterSkills
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
            => new Skill("Rotten hands", 5, UseFirstSkill, Descriptions.Zombie.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Undead", 13, UseSecondSkill, Descriptions.Zombie.SecondSkill);
    }
}
