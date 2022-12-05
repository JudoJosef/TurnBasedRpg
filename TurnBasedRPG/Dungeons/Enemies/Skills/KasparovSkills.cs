using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class KasparovSkills : IMonsterSkills
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
            var damage = monster.Strength * 2;
            var rounds = 2;
            GameHandler.AddDebuffs(targets, damage, rounds);
            GameHandler.SetCooldown(monster, 0);
            targets.ForEach(target => UiReferencer.WriteLine(Messages.DebuffTarget(((IMonster)monster).Type, ((IAlly)target).Type, rounds)));
            UiReferencer.WriteLineAndWait(string.Empty);
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Strength *= 4;
            GameHandler.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.IncreaseStats(((IMonster)monster).Type));
        }

        public static void UseThirdSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Health *= 3;
            monster.MaxHealth *= 3;
            GameHandler.SetCooldown(monster, 2);
            UiReferencer.WriteLineAndWait(Messages.IncreaseStats(((IMonster)monster).Type));
        }

        private static Skill GetFirstSkill()
            => new Skill("Lost Souls", 4, UseFirstSkill, Descriptions.Kasparov.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Warcry", 8, UseSecondSkill, Descriptions.Kasparov.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("We are the line", 12, UseThirdSkill, Descriptions.Kasparov.ThirdSkill);
    }
}
