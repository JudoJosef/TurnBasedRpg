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
            targets.ForEach(target => DungeonUtility.DealPhysicalDamage(target, damage));
            DungeonUtility.SetCooldown(monster, 0);
            UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IMonster)monster).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            if (monster.Health <= 0)
            {
                DungeonUtility.Revive(monster);
                DungeonUtility.SetCooldown(monster, 1);
                UiReferencer.WriteLineAndWait(Messages.ReviveTarget(((IMonster)monster).Type));
            }
        }

        private static Skill GetFirstSkill()
            => new Skill("Rotten hands", 5, UseFirstSkill, Descriptions.Zombie.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Undead", 13, UseSecondSkill, Descriptions.Zombie.SecondSkill);
    }
}
