namespace TurnBasedRPG.Classes.Skills
{
    internal class JojoSkills : IChampionSkills
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
            => new Skill("Intimidation", 3, UseFirstSkill, Descriptions.Jojo.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Star platinum", 5, UseSecondSkill, Descriptions.Jojo.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Star platinum: The World", 12, UseThirdSkill, Descriptions.Jojo.ThirdSkill);
    }
}
