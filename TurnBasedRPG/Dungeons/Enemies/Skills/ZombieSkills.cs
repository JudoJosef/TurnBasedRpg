namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class ZombieSkills : IMonsterSkills
    {
        public static List<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
            };

        public static void UseFirstSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = (int)(monster.Strength * 1.6);
            targets.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(monster, 0);
            Draw.WriteLineAndWait(Messages.UseAOESkill(monster, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            GameHandler.SetCooldown(monster, 1);
            Draw.WriteLineAndWait(Messages.ReviveTarget(monster));
        }

        private static Skill GetFirstSkill()
            => new Skill("Rotten hands", 5, UseFirstSkill, Descriptions.Zombie.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Undead", 13, UseSecondSkill, Descriptions.Zombie.SecondSkill);
    }
}
