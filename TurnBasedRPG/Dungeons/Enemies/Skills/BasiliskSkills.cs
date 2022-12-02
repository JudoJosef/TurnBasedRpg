using TurnBasedRPG.Classes;

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
            GameHandler.AddDebuffs(targets, damage, rounds);
            GameHandler.SetCooldown(monster, 0);
            targets.ForEach(target => Draw.WriteLine(Messages.DebuffTarget(((IMonster)monster).Type, ((IAlly)target).Type, rounds)));
            Draw.WriteLineAndWait(string.Empty);
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var target = GameHandler.GetRandomTarget(targets);
            var damage = monster.Strength * 2;
            GameHandler.DealMagicDamage(target, damage);
            GameHandler.SetCooldown(monster, 1);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Acid breath", 6, UseFirstSkill, Descriptions.Basilisk.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Stone eyes", 13, UseSecondSkill, Descriptions.Basilisk.SecondSkill);
    }
}
