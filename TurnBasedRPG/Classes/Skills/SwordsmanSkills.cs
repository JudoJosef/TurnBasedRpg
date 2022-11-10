namespace TurnBasedRPG.Classes.Skills
{
    internal class SwordsmanSkills : IChampionSkills
    {
        internal static IEnumerable<Skill> GetSkills()
            => new List<Skill>
            {
                GetSecondSkill(),
                GetFirstSkill(),
                GetThirdSkill(),
            };

        internal static void UseFirstSkill(Champion champion, List<ICreature> creatures)
        {
        }

        internal static void UseSecondSkill(Champion champion, List<ICreature> creatures)
        {
        }

        internal static void UseThirdSkill(Champion champion, List<ICreature> creatures)
        {
        }

        private static Skill GetFirstSkill()
            => new Skill("Dash and stab", 4, UseSecondSkill);

        private static Skill GetSecondSkill()
            => new Skill("Raging blade", 6, UseFirstSkill);

        private static Skill GetThirdSkill()
            => new Skill("Berserk", 9, UseThirdSkill);
    }
}
