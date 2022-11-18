using TurnBasedRPG.Classes;

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
            throw new NotImplementedException();
        }

        public void TurnAction(List<ICreature> creatures)
        {
            throw new NotImplementedException();
        }

        public void UseSkill(List<ICreature> creatures)
        {
            throw new NotImplementedException();
        }
    }
}
