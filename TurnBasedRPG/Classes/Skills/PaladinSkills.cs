using TurnBasedRPG.Dungeons;

namespace TurnBasedRPG.Classes.Skills
{
    public class PaladinSkills : IChampionSkills
    {
        public static List<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
                GetThirdSkill(),
            };

        public static void UseFirstSkill(ICreature champion, List<ICreature> creatures)
        {
            var shieldAmount = champion.Strength * 4;
            GameHandler.GiveShield(creatures, shieldAmount);
            GameHandler.SetCooldown(champion, 0);
            creatures.ForEach(creature => Draw.WriteLine(Messages.GetShield(creature)));
            Draw.WriteLineAndWait(string.Empty);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var amount = (int)(champion.Strength * 0.5);
            GameHandler.GiveArmor(creatures, amount);
            GameHandler.SetCooldown(champion, 1);
            creatures.ForEach(creature => Draw.WriteLine(Messages.IncreaseStats(creature)));
            Draw.WriteLineAndWait(string.Empty);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = champion.Strength * 4;
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(champion, 2);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(champion, target, champion.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Shield", 3, UseFirstSkill, Descriptions.Paladin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Armor blessing", 5, UseSecondSkill, Descriptions.Paladin.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Divine sword", 10, UseThirdSkill, Descriptions.Paladin.ThirdSkill);
    }
}
