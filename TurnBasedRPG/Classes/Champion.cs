using TurnBasedRPG.Lobby;

namespace TurnBasedRPG.Classes
{
    internal class Champion : IAlly
    {
        public Champion(
            double health,
            double physicDefense,
            double magicDefense,
            double strength,
            IEnumerable<Skill> skills,
            ClassTypes type)
        {
            Experience = 0;
            Health = health;
            PhysicDefense = physicDefense;
            MagicDefense = magicDefense;
            Strength = strength;
            Skills = skills;
            Type = type;
            Inventory = new ChampionInventory();
        }

        public double Experience { get; set; }
        public double Health { get; set; }
        public double PhysicDefense { get; set; }
        public double MagicDefense { get; set; }
        public double Strength { get; set; }

        public IEnumerable<Skill> Skills { get; }

        public ClassTypes Type { get; }
        public ChampionInventory Inventory { get; set; }

        public void TurnAction(List<ICreature> creatures)
        {
            throw new NotImplementedException();
        }

        public void Attack(ICreature creature)
        {
            throw new NotImplementedException();
        }

        public void Defend()
        {
            throw new NotImplementedException();
        }

        public void LevelUp(Upgrade upgrade)
        {
            throw new NotImplementedException();
        }

        public void UseSkill(List<ICreature> monsters)
        {
            throw new NotImplementedException();
        }

        public Item EquipItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
