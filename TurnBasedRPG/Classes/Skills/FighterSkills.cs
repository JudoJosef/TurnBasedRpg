using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Classes.Skills
{
    public class FighterSkills : IChampionSkills
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
            var damage = (int)(champion.Strength * 1.7);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(champion, 0);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = (int)(champion.Strength * 2.5);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(champion, 1);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.ElementAt(1).Name));
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = champion.Strength * 9;
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(champion, 2);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Iai chop", 2, UseFirstSkill, Descriptions.Fighter.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Jawbreaker", 5, UseSecondSkill, Descriptions.Fighter.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Ulimate series: serious punch", 18, UseThirdSkill, Descriptions.Fighter.ThirdSkill);
    }
}
