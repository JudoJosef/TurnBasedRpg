namespace TurnBasedRPG.Classes.Skills
{
    public class JojoSkills : IChampionSkills
    {
        public static IEnumerable<Skill> GetSkills()
            => new List<Skill>
            {
                GetSecondSkill(),
                GetFirstSkill(),
                GetThirdSkill(),
            };

        public static void UseFirstSkill(Champion champion, List<ICreature> creatures)
        {
        }

        public static void UseSecondSkill(Champion champion, List<ICreature> creatures)
        {
        }

        public static void UseThirdSkill(Champion champion, List<ICreature> creatures)
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
