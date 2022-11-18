namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class DragonSkills : IMonsterSkills
    {
        public static List<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
            };

        public static void UseFirstSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = monster.Strength * 4;
            targets.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(monster, 0);
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = monster.Strength * 8;
            targets.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(monster, 1);
        }

        private static Skill GetFirstSkill()
            => new Skill("Fiery breath", 5, UseFirstSkill, Descriptions.Dragon.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Magma stream", 10, UseSecondSkill, Descriptions.Dragon.SecondSkill);
    }
}
