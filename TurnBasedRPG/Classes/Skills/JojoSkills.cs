using TurnBasedRPG.Dungeons;

namespace TurnBasedRPG.Classes.Skills
{
    public class JojoSkills : IChampionSkills
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
            champion.Strength = (int)(champion.Strength * 1.1);
            var tempHealth = champion.MaxHealth;
            champion.MaxHealth = (int)(champion.MaxHealth * 1.1);
            champion.Health += champion.MaxHealth - tempHealth;
            champion.Armor = (int)(champion.Armor * 1.1);
            champion.MagicDefense = (int)(champion.MagicDefense * 1.1);
            GameHandler.SetCooldown(champion, 0);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = (int)(champion.Strength * 3.5);
            var target = GameHandler.GetTarget(creatures);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(champion, 1);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = (int)(champion.Strength * 5.5);

            for (int i = 0; i < 4; i++)
            {
                var target = GameHandler.GetTarget(creatures);
                GameHandler.DealPhysicalDamage(target, damage);
            }

            GameHandler.SetCooldown(champion, 2);
        }

        private static Skill GetFirstSkill()
            => new Skill("Intimidation", 3, UseFirstSkill, Descriptions.Jojo.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Star platinum", 5, UseSecondSkill, Descriptions.Jojo.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Star platinum: The World", 12, UseThirdSkill, Descriptions.Jojo.ThirdSkill);
    }
}
