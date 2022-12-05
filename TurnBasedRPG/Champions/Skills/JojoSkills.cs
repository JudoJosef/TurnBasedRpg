using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Classes.Skills
{
    public class JojoSkills : IChampionSkills
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
            champion.Strength = (int)(champion.Strength * 1.1);
            var tempHealth = champion.MaxHealth;
            champion.MaxHealth = (int)(champion.MaxHealth * 1.1);
            champion.Health += champion.MaxHealth - tempHealth;
            champion.Armor = (int)(champion.Armor * 1.1);
            champion.MagicDefense = (int)(champion.MagicDefense * 1.1);
            DungeonUtility.SetCooldown(champion, 0);
            UiReferencer.WriteLineAndWait(Messages.IncreaseStats(((IAlly)champion).Type));
        }

        public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = (int)(champion.Strength * 3.5);
            var target = DungeonUtility.GetTarget(creatures);
            DungeonUtility.DealPhysicalDamage(target, damage);
            DungeonUtility.SetCooldown(champion, 1);
            UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.ElementAt(1).Name));
        }

        public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
        {
            var damage = (int)(champion.Strength * 5.5);
            var targets = creatures.Where(creature => creature.Health > 0).ToList();

            for (int i = 0; i < 4; i++)
            {
                if (targets.Count != 0)
                {
                    UiReferencer.Clear();
                    UiReferencer.WriteMonsterStatTable(targets);
                    var target = DungeonUtility.GetTarget(targets);
                    DungeonUtility.DealPhysicalDamage(target, damage);
                    UiReferencer.WriteLine(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.Last().Name));
                    targets.Where(target => target.Health <= 0).ToList().ForEach(target => targets.Remove(target));
                }
                else
                {
                    break;
                }
            }

            DungeonUtility.SetCooldown(champion, 2);
        }

        private static Skill GetFirstSkill()
            => new Skill("Intimidation", 3, UseFirstSkill, Descriptions.Jojo.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Star platinum", 5, UseSecondSkill, Descriptions.Jojo.SecondSkill);

        private static Skill GetThirdSkill()
            => new Skill("Star platinum: The World", 12, UseThirdSkill, Descriptions.Jojo.ThirdSkill);
    }
}
