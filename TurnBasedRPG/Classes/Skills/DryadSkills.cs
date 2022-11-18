using TurnBasedRPG.Dungeons;
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

        public static void UseFirstSkill(ICreature champion, List<ICreature> creatures)
        {
            GameHandler.HealAllies(creatures);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = (int)(champion.Strength * 1.5);
            var rounds = 3;
            GameHandler.AddDebuffs(creatures, damage, rounds);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            GameHandler.Revive(target);
        }

        private static Skill GetFirstSkill()
            => new Skill("Gentle wind", 4, UseFirstSkill, Descriptions.Dryad.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Poison roots", 4, UseSecondSkill, Descriptions.Dryad.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Song of spring", 8, UseThirdSkill, Descriptions.Dryad.ThirdSkill);
    }
}
