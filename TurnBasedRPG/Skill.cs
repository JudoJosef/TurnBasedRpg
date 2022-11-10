using TurnBasedRPG.Classes;
using TurnBasedRPG.Enemies;

namespace TurnBasedRPG
{
    internal class Skill
    {
        public Skill(
            string name,
            int cooldown,
            Action<Champion, List<ICreature>> use)
        {
            Name = name;
            Cooldown = cooldown;
            ActualCooldown = 0;
            Use = use;
        }

        public string Name { get; }
        public int Cooldown { get; }
        public int ActualCooldown { get; set; }
        public Action<Champion, List<ICreature>> Use { get; }
    }
}
