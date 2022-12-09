using TurnBasedRPG.Champions;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class SoulEaterSkills : IMonsterSkills
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
            DungeonUtility.DealMagicDamage(target, damage);
            DungeonUtility.SetCooldown(monster, 0);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Health = (int)(monster.Health * 1.5);
            monster.MaxHealth = (int)(monster.MaxHealth * 1.5);
            monster.Strength = (int)(monster.Strength * 1.5);
            DungeonUtility.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.IncreaseStats(((IMonster)monster).Type));
        }

        public static void UseThirdSkill(ICreature monster, List<ICreature> targets)
        {
            var target = DungeonUtility.GetRandomTarget(targets);
            var damage = target.Health;
            DungeonUtility.DealPhysicalDamage(target, damage);
            var actualDamage = damage - target.Health;
            DungeonUtility.HealCreature(monster, actualDamage);
            DungeonUtility.SetCooldown(monster, 2);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Soul collector", 5, UseFirstSkill, Descriptions.SoulEater.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Warden of the dead", 13, UseSecondSkill, Descriptions.SoulEater.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Devour", 17, UseThirdSkill, Descriptions.SoulEater.ThirdSkill);
    }
}
