namespace TurnBasedRPG.Classes.Skills
{
    public class SwordsmanSkills : IChampionSkills
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
            => new Skill("Dash and stab", 4, UseSecondSkill, Descriptions.Swordsman.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Raging blade", 6, UseFirstSkill, Descriptions.Swordsman.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Berserk", 9, UseThirdSkill, Descriptions.Swordsman.ThirdSkill);
    }
}
