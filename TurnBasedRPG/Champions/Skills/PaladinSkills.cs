using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;

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
            DungeonUtility.GiveShield(creatures, shieldAmount);
            DungeonUtility.SetCooldown(champion, 0);
            creatures.ForEach(creature => UiReferencer.WriteLine(Messages.GetShield(((IAlly)creature).Type)));
            UiReferencer.WriteLineAndWait(string.Empty);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var amount = (int)(champion.Strength * 0.5);
            DungeonUtility.GiveArmor(creatures, amount);
            DungeonUtility.SetCooldown(champion, 1);
            creatures.ForEach(creature => UiReferencer.WriteLine(Messages.IncreaseStats(((IAlly)creature).Type)));
            UiReferencer.WriteLineAndWait(string.Empty);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = DungeonUtility.GetTarget(creatures);
            var damage = champion.Strength * 4;
            DungeonUtility.DealPhysicalDamage(target, damage);
            DungeonUtility.SetCooldown(champion, 2);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Shield", 3, UseFirstSkill, Descriptions.Paladin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Armor blessing", 5, UseSecondSkill, Descriptions.Paladin.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Divine sword", 10, UseThirdSkill, Descriptions.Paladin.ThirdSkill);
    }
}
