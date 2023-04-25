using TurnBasedRPG.Champions;

namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal class ModernTalkingSkills : IMonsterSkills
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
            DungeonUtility.AddDebuffs(targets, damage, rounds);
            DungeonUtility.SetCooldown(monster, 0);
            targets.ForEach(target => UiReferencer.WriteLine(Messages.DebuffTarget(((IMonster)monster).Type, ((IAlly)target).Type, rounds)));
            UiReferencer.WriteLineAndWait(string.Empty);
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Strength *= 4;
            DungeonUtility.SetCooldown(monster, 1);
            UiReferencer.WriteLineAndWait(Messages.IncreaseStats(((IMonster)monster).Type));
        }

        public static void UseThirdSkill(ICreature monster, List<ICreature> targets)
        {
            monster.Health *= 3;
            monster.MaxHealth *= 3;
            DungeonUtility.SetCooldown(monster, 2);
            UiReferencer.WriteLineAndWait(Messages.IncreaseStats(((IMonster)monster).Type));
        }

        private static Skill GetFirstSkill()
            => new Skill("You're my heart", 4, UseFirstSkill, Descriptions.ModernTalking.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Cheri cheri lady", 8, UseSecondSkill, Descriptions.ModernTalking.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Brother Louie", 12, UseThirdSkill, Descriptions.ModernTalking.ThirdSkill);
    }
}
