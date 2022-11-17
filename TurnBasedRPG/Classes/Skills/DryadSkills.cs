using TurnBasedRPG.Enemies;

namespace TurnBasedRPG.Classes.Skills
{
    public class DryadSkills : IChampionSkills
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
            => new Skill("Gentle wind", 4, UseFirstSkill, Descriptions.Dryad.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Poison roots", 4, UseSecondSkill, Descriptions.Dryad.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Song of spring", 8, UseThirdSkill, Descriptions.Dryad.ThirdSkill);
    }
}
