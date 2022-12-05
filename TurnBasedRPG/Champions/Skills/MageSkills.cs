using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Classes.Skills
{
    public class MageSkills : IChampionSkills
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
            var target = DungeonUtility.GetTarget(creatures);
            var damage = champion.Strength * 6;
            DungeonUtility.DealMagicDamage(target, damage);
            DungeonUtility.SetCooldown(champion, 0);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = champion.Strength;
            var rounds = 3;
            DungeonUtility.AddDebuffs(creatures, damage, rounds);
            DungeonUtility.SetCooldown(champion, 1);
            creatures.ForEach(creature => UiReferencer.WriteLine(Messages.DebuffTarget(((IAlly)champion).Type, ((IMonster)creature).Type, rounds)));
            UiReferencer.WriteLine(string.Empty);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = champion.Strength * 10;
            creatures.ForEach(creature => DungeonUtility.DealMagicDamage(creature, damage));
            DungeonUtility.SetCooldown(champion, 2);
            UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IAlly)champion).Type, champion.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Fireball", 2, UseFirstSkill, Descriptions.Mage.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Blizzard", 4, UseSecondSkill, Descriptions.Mage.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Lightning storm", 9, UseThirdSkill, Descriptions.Mage.ThirdSkill);
    }
}
