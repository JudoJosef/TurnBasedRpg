namespace TurnBasedRPG.Classes.Skills
{
    internal class FighterSkills : IChampionSkills
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
            => new Skill("Iai chop", 2, UseFirstSkill, Descriptions.Fighter.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Jawbreaker", 5, UseSecondSkill, Descriptions.Fighter.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Ulimate series: serious punch", 18, UseThirdSkill, Descriptions.Fighter.ThirdSkill);
    }
}
