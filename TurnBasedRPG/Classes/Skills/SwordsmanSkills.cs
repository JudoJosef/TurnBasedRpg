
using TurnBasedRPG.Dungeons;

namespace TurnBasedRPG.Classes.Skills
{
    public class SwordsmanSkills : IChampionSkills
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
            var target = GameHandler.GetTarget(creatures);
            var damage = champion.Strength * 2;
            GameHandler.DealPhysicalDamage( target, damage);
            GameHandler.SetCooldown(champion, 0);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IAlly)champion).Type, champion.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            champion.Strength = (int)(champion.Strength * 1.1);
            GameHandler.SetCooldown(champion, 1);
            Draw.WriteLineAndWait(Messages.IncreaseStats(((IAlly)champion).Type));
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = (int)(champion.Strength * 2.2);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(champion, 2);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IAlly)champion).Type, champion.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Dash and stab", 4, UseFirstSkill, Descriptions.Swordsman.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Raging blade", 6, UseSecondSkill, Descriptions.Swordsman.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Berserk", 9, UseThirdSkill, Descriptions.Swordsman.ThirdSkill);
    }
}
