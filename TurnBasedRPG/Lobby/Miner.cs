namespace TurnBasedRPG.Lobby;
public class Miner
{
    public int MiningForce { get; set; } = 1;

    public int MinedGold { get; set; }

    public int UpgradeCost { get; set; } = 100;

    public int Level { get; set; } = 1;

    public void Upgrade()
    {
        MiningForce++;
        Level++;
        UpgradeCost += 10;
    }

    public async void Work()
    {
        while (true)
        {
            MinedGold += MiningForce;
            await Task.Delay(1000);
        }
    }

    public int DeliverGold()
    {
        var gold = MinedGold;
        MinedGold = 0;

        return gold;
    }
}
