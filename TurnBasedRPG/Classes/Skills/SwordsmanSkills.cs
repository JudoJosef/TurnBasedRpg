
using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Enemies;

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

        public static void UseFirstSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = champion.Strength * 2;
            GameHandler.DealPhysicalDamage(champion, target, damage);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            champion.Strength = (int)(champion.Strength * 1.1);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = (int)(champion.Strength * 2.2);
            GameHandler.DealPhysicalDamage(champion, target, damage);
            GameHandler.DealPhysicalDamage(champion, target, damage);
            GameHandler.DealPhysicalDamage(champion, target, damage);
        }

        private static Skill GetFirstSkill()
            => new Skill("Dash and stab", 4, UseSecondSkill, Descriptions.Swordsman.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Raging blade", 6, UseFirstSkill, Descriptions.Swordsman.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Berserk", 9, UseThirdSkill, Descriptions.Swordsman.ThirdSkill);
    }
}
