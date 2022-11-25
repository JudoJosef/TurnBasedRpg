using System.Reflection;
using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Dungeons.Enemies;
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
            List<Skill> skills,
            ClassTypes type)
        {
            Experience = 0;
            Health = health;
            MaxHealth = health;
            Shield = 0;
            Armor = physicDefense;
            MagicDefense = magicDefense;
            Strength = strength;
            Skills = skills;
            Debuffs = new List<Debuff>();
            Type = type;
            Inventory = new ChampionInventory();
        }

        public double Experience { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int Shield { get; set; }
        public int Armor { get; set; }
        public int MagicDefense { get; set; }
        public int Strength { get; set; }

        public List<Skill> Skills { get; }
        public List<Debuff> Debuffs { get; set; }

        public ClassTypes Type { get; }
        public ChampionInventory Inventory { get; set; }

        public void TurnAction(List<ICreature> creatures)
        {
            var selected = Draw.SelectSingle(new List<string> { "Attack", "Use skill" }, "Select action");
            if (selected == "Attack")
                Attack(
                    GameHandler.GetTarget(
                        creatures.Where(creature =>
                            typeof(IMonster).IsAssignableFrom(creature.GetType()))
                        .ToList()));
            else
                UseSkill(creatures);
        }

        public void Attack(ICreature creature)
        {
            GameHandler.DealPhysicalDamage(creature, Strength);
            Draw.WriteLineAndWait(Messages.DamageTarget(Type, ((IMonster)creature).Type));
        }

        public void LevelUp(Upgrade upgrade)
        {
            throw new NotImplementedException();
        }

        public void UseSkill(List<ICreature> creatures)
        {
            Draw.WriteSkillTable(Skills);

            var selected = Draw.SelectSingle(Skills.Where(skill =>
                skill.ActualCooldown == 0)
                .Select(skill => skill.Name), "Select skill");
            var skill = Skills.Where(skill => skill.Name == selected).Single();
            if (selected == "Armor blessing" ||
                selected == "Gentle wind" ||
                selected == "Shield" ||
                selected == "Song of spring")
                skill.Use(
                    this,
                    creatures.Where(creature =>
                        typeof(IAlly).IsAssignableFrom(creature.GetType()))
                    .ToList());
            else
                skill.Use(
                    this,
                    creatures.Where(creature =>
                        typeof(IMonster).IsAssignableFrom(creature.GetType()))
                    .ToList());
        }

        public void EquipItem(Item item)
        {
            Inventory.Items.Add(item.Type, item);
            MaxHealth += item.Stats[StatTypes.Health];
            Health += item.Stats[StatTypes.Health];
            Strength += item.Stats[StatTypes.Strength];
            Armor += item.Stats[StatTypes.Armor];
            MagicDefense += item.Stats[StatTypes.MagicDefense];
        }

        public void UnEquipItem(Item item)
        {
            Inventory.Items.Remove(item.Type);
            MaxHealth -= item.Stats[StatTypes.Health];
            GetHealth(item.Stats[StatTypes.Health]);
            Strength -= item.Stats[StatTypes.Strength];
            Armor -= item.Stats[StatTypes.Armor];
            MagicDefense -= item.Stats[StatTypes.MagicDefense];
        }

        public void Die()
        {
            Draw.WriteLineAndWait(Messages.Defeated(Type));
        }

        private void GetHealth(int healthToRemove)
        {
            if ((Health - healthToRemove) <= 0)
            {
                Health = 1;
            }
            else
            {
                Health -= healthToRemove;
            }
        }
    }
}
