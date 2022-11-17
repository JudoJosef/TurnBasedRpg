using TurnBasedRPG.Enemies;

namespace TurnBasedRPG.Classes.Skills
{
    internal class ArcherSkills : IChampionSkills
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
            => new Skill("Charged shot", 3, UseFirstSkill, Descriptions.Archer.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Scattershot", 4, UseSecondSkill, Descriptions.Archer.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Arrow rain", 8, UseThirdSkill, Descriptions.Archer.ThirdSkill);
    }
}
