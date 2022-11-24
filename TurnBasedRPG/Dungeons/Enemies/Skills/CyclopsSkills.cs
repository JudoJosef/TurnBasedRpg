﻿namespace TurnBasedRPG.Dungeons.Enemies.Skills
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
            var target = GameHandler.GetRandomTarget(targets);
            var damage = monster.Strength * 7;
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(monster, 0);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(monster, target, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var damage = (int)(monster.Strength * 3.5);
            targets.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(monster, 1);
            Draw.WriteLineAndWait(Messages.UseAOESkill(monster, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Club masher", 3, UseFirstSkill, Descriptions.Cyclops.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Summon sheeps", 11, UseSecondSkill, Descriptions.Cyclops.SecondSkill);
    }
}
