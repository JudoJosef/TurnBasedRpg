using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class DemonKingSkills : IMonsterSkills
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
            var damage = monster.Strength * 3;
            DungeonUtility.DealMagicDamage(target, damage);
            DungeonUtility.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = monster.Strength * 2;
            var rounds = 2;
            DungeonUtility.AddDebuffs(targets, damage, rounds);
            DungeonUtility.SetCooldown(monster, 1);
            targets.ForEach(target => UiReferencer.WriteLine(Messages.DebuffTarget(((IMonster)monster).Type, ((IAlly)target).Type, rounds)));
            UiReferencer.WriteLineAndWait(string.Empty);
        }

        public static void UseThirdSkill(ICreature monster, List<ICreature> targets)
        {
            var damageValues = targets.Select(target => target.Health);
            targets.ForEach(target => DungeonUtility.DealPhysicalDamage(target, target.Health));
            var actualDamageValues = targets.Select(target => target.Health);

            for (int i = 0; i< damageValues.Count(); i++)
            {
                DungeonUtility.HealCreature(monster, damageValues.ElementAt(i) - actualDamageValues.ElementAt(i));
            }

            DungeonUtility.SetCooldown(monster, 2);
            UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IMonster)monster).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Dark beam", 8, UseFirstSkill, Descriptions.DemonKing.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Mind corruption", 11, UseSecondSkill, Descriptions.DemonKing.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("World ender", 13, UseThirdSkill, Descriptions.DemonKing.ThirdSkill);
    }
}
