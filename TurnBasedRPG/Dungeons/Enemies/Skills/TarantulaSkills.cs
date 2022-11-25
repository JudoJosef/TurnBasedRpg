using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class TarantulaSkills : IMonsterSkills
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
            var biteDamage = (int)(monster.Strength * 1.3);
            var dotDamage = (int)(monster.Strength * 1.5);
            var rounds = 3;
            GameHandler.DealTrueDamage(target, biteDamage);
            GameHandler.AddDebuff(target, dotDamage, rounds);
            GameHandler.SetCooldown(monster, 0);
            Draw.WriteLineAndWait(Messages.DebuffTarget(((IMonster)monster).Type, ((IAlly)target).Type, rounds));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            var target = GameHandler.GetRandomTarget(targets);
            var damage = (int)(monster.Strength * 2.5);
            GameHandler.DealMagicDamage(target, damage);
            GameHandler.SetCooldown(monster, 1);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Venomous bite", 4, UseFirstSkill, Descriptions.Tarantula.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Webshot", 7, UseSecondSkill, Descriptions.Tarantula.SecondSkill);
    }
}
