using TurnBasedRPG.Dungeons;

namespace TurnBasedRPG.Classes.Skills
{
    public class PaladinSkills : IChampionSkills
    {
        public static IEnumerable<Skill> GetSkills()
            => new List<Skill>
            {
                GetSecondSkill(),
                GetFirstSkill(),
                GetThirdSkill(),
            };

        public static void UseFirstSkill(ICreature champion, List<ICreature> creatures)
        {
            var shieldAmount = ((Champion)champion).Strength * 4;
            GameHandler.GiveShield(creatures, shieldAmount);
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var amount = (int)(((Champion)champion).Strength * 0.5);
            GameHandler.GiveArmor(creatures, amount);
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var target = GameHandler.GetTarget(creatures);
            var damage = ((Champion)champion).Strength * 4;
            GameHandler.DealPhysicalDamage(target, damage);
        }

        private static Skill GetFirstSkill()
            => new Skill("Shield", 3, UseSecondSkill, Descriptions.Paladin.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Armor blessing", 5, UseFirstSkill, Descriptions.Paladin.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Divine sword", 10, UseThirdSkill, Descriptions.Paladin.ThirdSkill);
    }
}
