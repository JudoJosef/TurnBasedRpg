﻿using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class GoblinSkills : IMonsterSkills
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
            var damage = (int)(monster.Strength * 1.5);
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(monster, 0);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var target = GameHandler.GetRandomTarget(targets);
            GameHandler.StealItem(target);
            GameHandler.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.StealItem(((IMonster)monster).Type, ((IAlly)target).Type));
        }

        private static Skill GetFirstSkill()
            => new Skill("Jumpattack", 3, UseFirstSkill, Descriptions.Goblin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Steal", 10, UseSecondSkill, Descriptions.Goblin.SecondSkill);
    }
}
