﻿using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Dungeons.Enemies
{
    public class Monster : IMonster
    {
        public Monster(
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

        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Armor { get; set; }
        public int MagicDefense { get; set; }
        public int Strength { get; set; }

        public List<Skill> Skills { get; }
        public List<Debuff> Debuffs { get; set; }

        public int ExperienceToDrop { get; set; }
        public EnemyTypes Type { get; }

        public void Attack(ICreature creature)
        {
            GameHandler.DealPhysicalDamage(creature, Strength);
            Draw.WriteLineAndWait(Messages.DamageTarget(this, creature));
        }

        public void TurnAction(List<ICreature> creatures)
        {
            var rnd = new Random();
            if (rnd.Next(1, 11) <= 6)
                Attack(GameHandler.GetRandomTarget(creatures));
            else
                UseSkill(creatures);
        }

        public void UseSkill(List<ICreature> creatures)
        {
            var rnd = new Random();

            if (rnd.Next(1, 11) <= 5 && Skills.First().ActualCooldown == 0)
                Skills.First().Use(this, creatures);
            else if (Skills.Last().ActualCooldown == 0)
                Skills.Last().Use(this, creatures);
            else if (Skills.First().ActualCooldown == 0)
                Skills.First().Use(this, creatures);
            else
                Attack(GameHandler.GetRandomTarget(creatures));
        }
    }
}
