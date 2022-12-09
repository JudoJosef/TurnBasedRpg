using TurnBasedRPG.Champions;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class WolfpackSkills : IMonsterSkills
    {
        public static List<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
            };

        public static void UseFirstSkill(ICreature monster, List<ICreature> targets)
        {
            var target = DungeonUtility.GetRandomTarget(targets);
            var damage = monster.Strength * 2;
            DungeonUtility.DealPhysicalDamage(target, damage);
            DungeonUtility.SetCooldown(monster, 0);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Strength = (int)(monster.Strength * 1.2);
            DungeonUtility.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.IncreaseStats(((IMonster)monster).Type));
        }

        private static Skill GetFirstSkill()
            => new Skill("On the hunt", 4, UseFirstSkill, Descriptions.Wolfpack.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Howl", 8, UseSecondSkill, Descriptions.Wolfpack.SecondSkill);
    }
}
