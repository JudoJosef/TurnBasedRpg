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
            var target = GameHandler.GetRandomTarget(targets);
            var damage = monster.Strength * 2;
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(monster, 0);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(monster, target, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Strength = (int)(monster.Strength * 1.2);
            GameHandler.SetCooldown(monster, 1);
            Draw.WriteLineAndWait(Messages.IncreaseStats(monster));
        }

        private static Skill GetFirstSkill()
            => new Skill("On the hunt", 4, UseFirstSkill, Descriptions.Wolfpack.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Howl", 8, UseSecondSkill, Descriptions.Wolfpack.SecondSkill);
    }
}
