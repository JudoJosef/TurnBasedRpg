using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Classes.Skills
{
    public class ArcherSkills : IChampionSkills
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
            var target = GameHandler.GetTarget(creatures);
            var damage = ((Champion)champion).Strength * 3;
            GameHandler.DealPhysicalDamage(target, damage);
            GameHandler.SetCooldown(champion, 0);
            Draw.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.First().Name));
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = (int)(((Champion)champion).Strength * 1.5);
            creatures.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(champion, 1);
            Draw.WriteLineAndWait(Messages.UseAOESkill(((IAlly)champion).Type, champion.Skills.ElementAt(1).Name));
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = ((Champion)champion).Strength * 4;
            creatures.ForEach(target => GameHandler.DealPhysicalDamage(target, damage));
            GameHandler.SetCooldown(champion, 2);
            Draw.WriteLineAndWait(Messages.UseAOESkill(((IAlly)champion).Type, champion.Skills.Last().Name));
        }

        private static Skill GetFirstSkill()
            => new Skill("Charged shot", 3, UseFirstSkill, Descriptions.Archer.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Scattershot", 4, UseSecondSkill, Descriptions.Archer.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Arrow rain", 8, UseThirdSkill, Descriptions.Archer.ThirdSkill);
    }
}
