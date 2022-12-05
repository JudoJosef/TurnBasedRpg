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
            var damage = (int)(monster.Strength * 1.3);
            targets.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(monster, 0);
            UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IMonster)monster).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = monster.Strength * 2;
            targets.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IMonster)monster).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Fiery breath", 5, UseFirstSkill, Descriptions.Dragon.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Magma stream", 10, UseSecondSkill, Descriptions.Dragon.SecondSkill);
    }
}
