using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Classes.Skills
{
    public class DryadSkills : IChampionSkills
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
            DungeonUtility.HealAllies(creatures.Where(creature => creature.Health > 0).ToList());
            DungeonUtility.SetCooldown(champion, 0);
            creatures.ForEach(creature => UiReferencer.WriteLine(Messages.HealTarget(((IAlly)champion).Type, ((IAlly)creature).Type)));
            UiReferencer.WriteLineAndWait(string.Empty);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = (int)(champion.Strength * 1.5);
            var rounds = 3;
            DungeonUtility.AddDebuffs(creatures, damage, rounds);
            DungeonUtility.SetCooldown(champion, 1);
            creatures.ForEach(creature => UiReferencer.WriteLine(Messages.DebuffTarget(((IAlly)champion).Type, ((IMonster)creature).Type, rounds)));
            UiReferencer.WriteLineAndWait(string.Empty);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = DungeonUtility.GetAlly(creatures.Where(creature => creature.Health <= 0).ToList());
            DungeonUtility.Revive(target);
            DungeonUtility.SetCooldown(champion, 2);
            UiReferencer.WriteLineAndWait(Messages.ReviveTarget(((IAlly)target).Type));
        }

        private static Skill GetFirstSkill()
            => new Skill("Gentle wind", 4, UseFirstSkill, Descriptions.Dryad.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Poison roots", 4, UseSecondSkill, Descriptions.Dryad.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Song of spring", 8, UseThirdSkill, Descriptions.Dryad.ThirdSkill);
    }
}
