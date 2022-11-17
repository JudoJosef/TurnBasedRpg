using TurnBasedRPG.Enemies;

namespace TurnBasedRPG.Classes.Skills
{
    internal class DryadSkills : IChampionSkills
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
            => new Skill("Gentle wind", 4, UseFirstSkill, Descriptions.Dryad.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Poison roots", 4, UseSecondSkill, Descriptions.Dryad.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Song of spring", 8, UseThirdSkill, Descriptions.Dryad.ThirdSkill);
    }
}
