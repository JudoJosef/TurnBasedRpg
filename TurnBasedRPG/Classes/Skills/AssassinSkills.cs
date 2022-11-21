using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Classes.Skills
{
    public class AssassinSkills : IChampionSkills
    {
        public static List<Skill> GetSkills()
            => new List<Skill>
            {
                GetSecondSkill(),
                GetFirstSkill(),
                GetThirdSkill(),
            };

        public static void UseFirstSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = champion.Strength * 3;
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(champion, 0);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = (int)(champion.Strength * 1.8);
            creatures.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(champion, 1);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = target.Health;
            if (target.GetType() != typeof(Boss))
                GameHandler.DealTrueDamage(target, damage);
            else
                GameHandler.DealPhysicalDamage(target, damage);

            GameHandler.SetCooldown(champion, 2);
        }

        private static Skill GetFirstSkill()
            => new Skill("Throwingknifes", 4, UseFirstSkill, Descriptions.Assassin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Daggerstorm", 6, UseSecondSkill, Descriptions.Assassin.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Stealthkill", 10, UseThirdSkill, Descriptions.Assassin.ThirdSkill);
    }
}
