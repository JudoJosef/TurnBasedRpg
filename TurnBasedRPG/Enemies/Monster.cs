namespace TurnBasedRPG.Enemies
{
    internal class Monster : IMonster
    {
        public Monster(
            double health,
            double physicDefense,
            double magicDefense,
            double strength,
            IEnumerable<Skill> skills,
            int experienceToDrop,
            EnemyTypes type)
        {
            Health = health;
            Armor = physicDefense;
            MagicDefense = magicDefense;
            Strength = strength;
            Skills = skills;
            ExperienceToDrop = experienceToDrop;
            Type = type;
        }

        public double Health { get; set; }
        public double Armor { get; set; }
        public double MagicDefense { get; set; }
        public double Strength { get; set; }

        public IEnumerable<Skill> Skills { get; }

        public int ExperienceToDrop { get; set; }
        public EnemyTypes Type { get; }

        public void Attack(ICreature creature)
        {
            throw new NotImplementedException();
        }

        public void Defend()
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
