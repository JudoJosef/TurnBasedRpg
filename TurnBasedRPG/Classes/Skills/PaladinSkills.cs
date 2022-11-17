namespace TurnBasedRPG.Classes.Skills
{
    internal class PaladinSkills : IChampionSkills
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
            => new Skill("Shield", 3, UseSecondSkill, Descriptions.Paladin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Armor blessing", 5, UseFirstSkill, Descriptions.Paladin.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Divine sword", 10, UseThirdSkill, Descriptions.Paladin.ThirdSkill);
    }
}
