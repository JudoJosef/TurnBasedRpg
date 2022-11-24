using TurnBasedRPG.Dungeons;

namespace TurnBasedRPG.Classes.Skills
{
    public class DryadSkills : IChampionSkills
    {
        public static List<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
                GetThirdSkill(),
            };

        public static void UseFirstSkill(ICreature champion, List<ICreature> creatures)
        {
            GameHandler.HealAllies(creatures);
            GameHandler.SetCooldown(champion, 0);
            creatures.ForEach(creature => Draw.WriteLine(Messages.HealTarget(champion, creature)));
            Draw.WriteLineAndWait(string.Empty);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = (int)(champion.Strength * 1.5);
            var rounds = 3;
            GameHandler.AddDebuffs(creatures, damage, rounds);
            GameHandler.SetCooldown(champion, 1);
            creatures.ForEach(creature => Draw.WriteLine(Messages.DebuffTarget(champion, creature, rounds)));
            Draw.WriteLineAndWait(string.Empty);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetAlly(creatures);
            GameHandler.Revive(target);
            GameHandler.SetCooldown(champion, 2);
            Draw.WriteLineAndWait(Messages.ReviveTarget(target));
        }

        private static Skill GetFirstSkill()
            => new Skill("Gentle wind", 4, UseFirstSkill, Descriptions.Dryad.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Poison roots", 4, UseSecondSkill, Descriptions.Dryad.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Song of spring", 8, UseThirdSkill, Descriptions.Dryad.ThirdSkill);
    }
}
