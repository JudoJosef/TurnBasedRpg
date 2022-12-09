using TurnBasedRPG.Champions;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class BasiliskSkills : IMonsterSkills
    {
        public static List<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
            };

        public static void UseFirstSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = (int)(monster.Strength * 1.1);
            var rounds = 2;
            DungeonUtility.AddDebuffs(targets, damage, rounds);
            DungeonUtility.SetCooldown(monster, 0);
            targets.ForEach(target => UiReferencer.WriteLine(Messages.DebuffTarget(((IMonster)monster).Type, ((IAlly)target).Type, rounds)));
            UiReferencer.WriteLineAndWait(string.Empty);
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var target = DungeonUtility.GetRandomTarget(targets);
            var damage = monster.Strength * 2;
            DungeonUtility.DealMagicDamage(target, damage);
            DungeonUtility.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Acid breath", 6, UseFirstSkill, Descriptions.Basilisk.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Stone eyes", 13, UseSecondSkill, Descriptions.Basilisk.SecondSkill);
    }
}
