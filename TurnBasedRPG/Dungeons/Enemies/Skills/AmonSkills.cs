using TurnBasedRPG.Champions;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class AmonSkills : IMonsterSkills
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
            var damage = monster.Strength * 5;
            targets.ForEach(target => DungeonUtility.DealMagicDamage(target, damage));
            DungeonUtility.SetCooldown(monster, 0);
            UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IMonster)monster).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Strength = monster.Strength * 2;
            monster.Health = monster.Health * 2;
            monster.MaxHealth = monster.MaxHealth * 2;
            DungeonUtility.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.IncreaseStats(((IMonster)monster).Type));
        }

        public static void UseThirdSkill(ICreature monster, List<ICreature> targets)
        {
            var target = DungeonUtility.GetRandomTarget(targets);
            var damage = monster.Strength * 8;
            DungeonUtility.DealPhysicalDamage(target, damage);
            DungeonUtility.SetCooldown(monster, 2);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Hellflare", 4, UseFirstSkill, Descriptions.Amon.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Song of fallen feathers", 7, UseSecondSkill, Descriptions.Amon.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Infernal legion", 9, UseThirdSkill, Descriptions.Amon.ThirdSkill);
    }
}
