using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Player
{
    public class Summoner
    {
        public Summoner(List<Champion> champions, SummonerInventory inventory)
        {
            Champions = champions;
            Inventory = inventory;
        }

        public List<Champion> Champions { get; }
        public SummonerInventory Inventory { get; }
    }
}
