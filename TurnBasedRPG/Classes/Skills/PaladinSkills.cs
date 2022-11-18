using TurnBasedRPG.Dungeons;

namespace TurnBasedRPG.Classes.Skills
{
    public class PaladinSkills : IChampionSkills
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
            var shieldAmount = champion.Strength * 4;
            GameHandler.GiveShield(creatures, shieldAmount);
            GameHandler.SetCooldown(champion, 0);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var amount = (int)(champion.Strength * 0.5);
            GameHandler.GiveArmor(creatures, amount);
            GameHandler.SetCooldown(champion, 1);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = champion.Strength * 4;
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(champion, 2);
        }

        private static Skill GetFirstSkill()
            => new Skill("Shield", 3, UseSecondSkill, Descriptions.Paladin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Armor blessing", 5, UseFirstSkill, Descriptions.Paladin.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Divine sword", 10, UseThirdSkill, Descriptions.Paladin.ThirdSkill);
    }
}
