using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Champions.Skills;

public class AssassinSkills : IChampionSkills
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
        var target = DungeonUtility.GetTarget(creatures);
        var damage = champion.Strength * 3;
        DungeonUtility.DealPhysicalDamage(target, damage);
        DungeonUtility.SetCooldown(champion, 0);
        UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.First().Name));
    }

    public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
    {
        var damage = (int)(champion.Strength * 1.8);
        creatures.ForEach(target => DungeonUtility.DealPhysicalDamage(target, damage));
        DungeonUtility.SetCooldown(champion, 1);
        UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IAlly)champion).Type, champion.Skills.ElementAt(1).Name));
    }

    public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
    {
        var target = DungeonUtility.GetTarget(creatures);
        var damage = target.Health;
        if (target.GetType() != typeof(Boss))
        {
            DungeonUtility.DealTrueDamage(target, damage);
        }
        else
        {
            DungeonUtility.DealPhysicalDamage(target, damage);
        }

        DungeonUtility.SetCooldown(champion, 2);
        UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.Last().Name));
    }

    private static Skill GetFirstSkill()
        => new Skill("Throwingknifes", 4, UseFirstSkill, Descriptions.Assassin.FirstSkill);

    private static Skill GetSecondSkill()
        => new Skill("Daggerstorm", 6, UseSecondSkill, Descriptions.Assassin.SecondSkill);

    private static Skill GetThirdSkill()
        => new Skill("Stealthkill", 10, UseThirdSkill, Descriptions.Assassin.ThirdSkill);
}
