using TurnBasedRPG.Lobby.Items;

namespace TurnBasedRPG.Classes
{
    public class Champion : IAlly
    {
        public Champion(
            int health,
            int physicDefense,
            int magicDefense,
            int strength,
            IEnumerable<Skill> skills,
            ClassTypes type)
        {
            Experience = 0;
            Health = health;
            Shield = 0;
            Armor = physicDefense;
            MagicDefense = magicDefense;
            Strength = strength;
            Skills = skills;
            Type = type;
            Inventory = new ChampionInventory();
        }

        public double Experience { get; set; }
        public int Health { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int MagicDefense { get; set; }
        public int Strength { get; set; }

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
