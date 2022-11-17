using TurnBasedRPG.Classes;
using TurnBasedRPG.Enemies;

namespace TurnBasedRPG
{
    public class Skill
    {
        public Skill(
            string name,
            int cooldown,
            Action<ICreature, List<ICreature>> use,
            string description)
        {
            Name = name;
            Cooldown = cooldown;
            ActualCooldown = 0;
            Use = use;
            Description = description;
        }

        public string Name { get; }
        public int Cooldown { get; }
        public int ActualCooldown { get; set; }
        public Action<ICreature, List<ICreature>> Use { get; }
        public string Description { get; }
    }
}
