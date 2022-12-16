using TurnBasedRPG.Champions;
using TurnBasedRPG.Dungeons.Enemies;

namespace TurnBasedRPG.Player;

public class Summoner
{
    public Summoner(List<Champion> champions, SummonerInventory inventory)
    {
        Champions = champions;
        Inventory = inventory;
        DefeatedCreatures = new List<IMonster>();
    }

    public List<Champion> Champions { get; }

    public SummonerInventory Inventory { get; }

    public List<IMonster> DefeatedCreatures { get; set; }
}
