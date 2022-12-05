using TurnBasedRPG.Classes;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Player
{
    public class Summoner
    {
        public Summoner(List<Champion> champions, SummonerInventory inventory, int id)
        {
            Champions = champions;
            Inventory = inventory;
            DefeatedCreatures = new List<IMonster>();
            Id = id;
        }

        public int Id { get; }
        public List<Champion> Champions { get; }
        public SummonerInventory Inventory { get; }
        public List<IMonster> DefeatedCreatures { get; set; }
    }
}
