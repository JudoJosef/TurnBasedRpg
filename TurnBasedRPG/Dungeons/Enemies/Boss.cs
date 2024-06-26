﻿using TurnBasedRPG.Champions;

namespace TurnBasedRPG.Dungeons.Enemies;

public class Boss : IMonster
{
    public Boss(
        int health,
        int physicDefense,
        int magicDefense,
        int strength,
        List<Skill> skills,
        int experienceToDrop,
        EnemyTypes type)
    {
        Health = health;
        MaxHealth = health;
        Armor = physicDefense;
        MagicDefense = magicDefense;
        Strength = strength;
        Skills = skills;
        Debuffs = new List<Debuff>();
        ExperienceToDrop = experienceToDrop;
        Type = type;
    }

    public int ExperienceToDrop { get; set; }

    public int Health { get; set; }

    public int MaxHealth { get; set; }

    public int Armor { get; set; }

    public int MagicDefense { get; set; }

    public int Strength { get; set; }

    public EnemyTypes Type { get; }

    public List<Skill> Skills { get; set; }

    public List<Debuff> Debuffs { get; set; }

    public void Attack(ICreature creature)
    {
        DungeonUtility.DealPhysicalDamage(creature, Strength);
        UiReferencer.WriteLineAndWait(Messages.DamageTarget(Type, ((IAlly)creature).Type));
    }

    public void Die()
    {
        UiReferencer.WriteLineAndWait(Messages.Defeated(Type));
    }

    public void TurnAction(List<ICreature> creatures)
    {
        DungeonUtility.TickDebuff(Debuffs, this);

        var rnd = new Random();
        if (rnd.Next(1, 11) <= 6)
        {
            Attack(DungeonUtility.GetRandomTarget(creatures));
        }
        else
        {
            UseSkill(creatures);
        }
    }

    public void UseSkill(List<ICreature> creatures)
    {
        var availableSkills = Skills.Where(skill => skill.ActualCooldown == 0);

        if (availableSkills.Count() != 0)
        {
            var rnd = new Random();
            var index = rnd.Next(0, availableSkills.Count());

            availableSkills.ElementAt(index).Use(this, creatures);
        }
        else
        {
            Attack(DungeonUtility.GetRandomTarget(creatures));
        }
    }
}
