namespace TurnBasedRPG.Classes.Skills
{
    public class MageSkills : IChampionSkills
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
            => new Skill("Fireball", 2, UseFirstSkill, Descriptions.Mage.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Blizzard", 4, UseSecondSkill, Descriptions.Mage.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Lightning storm", 9, UseThirdSkill, Descriptions.Mage.ThirdSkill);
    }
}
