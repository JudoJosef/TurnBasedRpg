using TurnBasedRPG.Dungeons;

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

        public static void UseFirstSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = champion.Strength * 6;
            GameHandler.DealMagicDamage(target, damage);
            GameHandler.SetCooldown(champion, 0);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = champion.Strength;
            var rounds = 3;
            GameHandler.AddDebuffs(creatures, damage, rounds);
            GameHandler.SetCooldown(champion, 1);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = champion.Strength * 10;
            creatures.ForEach(creature => GameHandler.DealMagicDamage(creature, damage));
            GameHandler.SetCooldown(champion, 2);
        }

        private static Skill GetFirstSkill()
            => new Skill("Fireball", 2, UseFirstSkill, Descriptions.Mage.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Blizzard", 4, UseSecondSkill, Descriptions.Mage.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Lightning storm", 9, UseThirdSkill, Descriptions.Mage.ThirdSkill);
    }
}
