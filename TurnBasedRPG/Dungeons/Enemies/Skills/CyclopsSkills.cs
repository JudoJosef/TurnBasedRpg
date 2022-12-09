using TurnBasedRPG.Champions;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class CyclopsSkills : IMonsterSkills
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
            var damage = monster.Strength * 3;
            DungeonUtility.DealPhysicalDamage(target, damage);
            DungeonUtility.SetCooldown(monster, 0);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = (int)(monster.Strength * 2.5);
            targets.ForEach(target => DungeonUtility.DealPhysicalDamage(target, damage));
            DungeonUtility.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IMonster)monster).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Club masher", 3, UseFirstSkill, Descriptions.Cyclops.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Summon sheeps", 11, UseSecondSkill, Descriptions.Cyclops.SecondSkill);
    }
}
