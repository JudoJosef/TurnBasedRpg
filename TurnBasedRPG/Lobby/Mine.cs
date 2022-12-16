using TurnBasedRPG.Player;
using static TurnBasedRPG.Constants;

namespace TurnBasedRPG.Lobby;
internal class Mine
{
    private Summoner _summoner;
    private int _minedGold = 0;

    public Mine(Summoner summoner)
    {
        _summoner = summoner;
    }

    public void Open()
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            UiReferencer.Clear();
            selected = UiReferencer.SelectSingle(new List<string> { ManageWorkersOption, CollectOption, BackOption }, SelectOptionCaption);

            if (selected == ManageWorkersOption)
            {
                ManageWorkers();
            }
            else if (selected == CollectOption)
            {
                CollectGold();
            }
        }
    }

    private void CollectGold()
    {
        UiReferencer.WriteLineAndWait($"{_minedGold} gold collected");
        _summoner.Inventory.Gold += _minedGold;
        _minedGold = 0;
    }

    private void ManageWorkers()
    {
    }

    private void BuyWorker()
    {
    }
}
