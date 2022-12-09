using TurnBasedRPG.Champions;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class GhostSamuraiSkills : IMonsterSkills
    {
        public static List<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
                GetThirdSkill(),
            };

        public static void UseFirstSkill(ICreature monster, List<ICreature> targets)
        {
            var target = DungeonUtility.GetRandomTarget(targets);
            var damage = monster.Strength * 6;
            DungeonUtility.DealPhysicalDamage(target, damage);
            DungeonUtility.SetCooldown(monster, 0);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            targets.ForEach(target => target.Strength = (int)(target.Strength * 0.9));
            DungeonUtility.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IMonster)monster).Type, monster.Skills.ElementAt(1).Name));
        }

        public static void UseThirdSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Strength = monster.Strength * 7;
            DungeonUtility.SetCooldown(monster, 2);
            UiReferencer.WriteLineAndWait(Messages.IncreaseStats(((IMonster)monster).Type));
        }

        private static Skill GetFirstSkill()
            => new Skill("Quickdraw", 3, UseFirstSkill, Descriptions.GhostSamurai.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Wandering mist", 6, UseSecondSkill, Descriptions.GhostSamurai.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Kenjutsu", 18, UseThirdSkill, Descriptions.GhostSamurai.ThirdSkill);
    }
}
