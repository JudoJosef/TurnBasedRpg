using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Champions.Skills;

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
        var target = DungeonUtility.GetTarget(creatures);
        var damage = ((Champion)champion).Strength * 3;
        DungeonUtility.DealPhysicalDamage(target, damage);
        DungeonUtility.SetCooldown(champion, 0);
        UiReferencer.WriteLineAndWait(Messages.UseSingleTargetSkill(((IAlly)champion).Type, ((IMonster)target).Type, champion.Skills.First().Name));
    }

    public static void UseSecondSkill(ICreature champion, List<ICreature> creatures)
    {
        var damage = (int)(((Champion)champion).Strength * 1.5);
        creatures.ForEach(target => DungeonUtility.DealPhysicalDamage(target, damage));
        DungeonUtility.SetCooldown(champion, 1);
        UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IAlly)champion).Type, champion.Skills.ElementAt(1).Name));
    }

    public static void UseThirdSkill(ICreature champion, List<ICreature> creatures)
    {
        var damage = ((Champion)champion).Strength * 4;
        creatures.ForEach(target => DungeonUtility.DealPhysicalDamage(target, damage));
        DungeonUtility.SetCooldown(champion, 2);
        UiReferencer.WriteLineAndWait(Messages.UseAOESkill(((IAlly)champion).Type, champion.Skills.Last().Name));
    }

    private static Skill GetFirstSkill()
        => new Skill("Charged shot", 3, UseFirstSkill, Descriptions.Archer.FirstSkill);

    private static Skill GetSecondSkill()
        => new Skill("Scattershot", 4, UseSecondSkill, Descriptions.Archer.SecondSkill);

    private static Skill GetThirdSkill()
        => new Skill("Arrow rain", 8, UseThirdSkill, Descriptions.Archer.ThirdSkill);
}
