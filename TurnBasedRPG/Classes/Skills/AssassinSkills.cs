namespace TurnBasedRPG.Classes.Skills
{
    public class AssassinSkills : IChampionSkills
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
            => new Skill("Throwingknifes", 4, UseFirstSkill, Descriptions.Assassin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Daggerstorm", 6, UseSecondSkill, Descriptions.Assassin.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Stealthkill", 10, UseThirdSkill, Descriptions.Assassin.ThirdSkill);
    }
}
