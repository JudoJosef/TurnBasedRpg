using TurnBasedRPG.Classes;

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
            var damage = monster.Strength * 13;
            targets.ForEach(target => GameHandler.DealMagicDamage(target, damage));
            GameHandler.SetCooldown(monster, 0);
            Draw.WriteLineAndWait(Messages.UseAOESkill(((IMonster)monster).Type, monster.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Strength = monster.Strength * 4;
            monster.Health = monster.Health * 4;
            monster.MaxHealth = monster.MaxHealth * 4;
            monster.Armor = monster.Armor * 4;
            monster.MagicDefense = monster.MagicDefense * 4;
            GameHandler.SetCooldown(monster, 1);
            Draw.WriteLineAndWait(Messages.IncreaseStats(((IMonster)monster).Type));
        }

        public static void UseThirdSkill(ICreature monster, List<ICreature> targets)
        {
            var target = GameHandler.GetRandomTarget(targets);
            var damage = monster.Strength * 8;
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(monster, 2);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(((IMonster)monster).Type, ((IAlly)target).Type, monster.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Hellflare", 4, UseFirstSkill, Descriptions.Amon.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Song of fallen feathers", 1, UseSecondSkill, Descriptions.Amon.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Infernal legion", 9, UseSecondSkill, Descriptions.Amon.ThirdSkill);
    }
}
