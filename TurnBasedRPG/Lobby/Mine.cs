using TurnBasedRPG.Player;
using static TurnBasedRPG.Constants;

namespace TurnBasedRPG.Lobby;
internal class Mine
{
    private Summoner _summoner;
    private int _minedGold = 0;
    private List<Miner> _miners = new List<Miner>();

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
        _miners.ForEach(miner => _minedGold += miner.DeliverGold());
        _summoner.Inventory.Gold += _minedGold;
        UiReferencer.WriteLineAndWait($"{_minedGold} gold collected");
        _minedGold = 0;
    }

    private void ManageWorkers()
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            selected = UiReferencer.SelectSingle(new List<string> { BuyMinerOption, UpgradeOption, BackOption }, SelectOptionCaption);

            if (selected == BuyMinerOption)
            {
                TryBuyWorker();
            }
            else if (selected == UpgradeOption)
            {
                SelectWorker();
            }
        }
    }

    private void SelectWorker()
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            UiReferencer.WriteMinerTable(_miners);
            selected = UiReferencer.SelectSingle(ListWorkers().Concat(new List<string> { BackOption }), SelectWorkerCaption);

            if (selected != BackOption)
            {
                TryUpgradeWorker(ParseMiner(selected));
            }

            UiReferencer.Clear();
        }
    }

    private void TryUpgradeWorker(Miner miner)
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            selected = UiReferencer.SelectSingle(new List<string> { UpgradeMinerOption(miner.UpgradeCost), BackOption }, SelectOptionCaption);

            if (selected != BackOption)
            {
                if (_summoner.Inventory.Gold >= miner.UpgradeCost)
                {
                    miner.Upgrade();
                    _summoner.Inventory.Gold -= miner.UpgradeCost;
                }
                else
                {
                    UiReferencer.WriteLineAndWait(NotEnoughGoldCaption);
                }
            }
        }
    }

    private void TryBuyWorker()
    {
        if (_summoner.Inventory.Gold >= 100 && _miners.Count() < 5)
        {
            BuyWorker();
        }
        else if (_miners.Count() == 5)
        {
            UiReferencer.WriteLineAndWait(TooManyMinersCaption);
        }
        else
        {
            UiReferencer.WriteLineAndWait(NotEnoughGoldCaption);
        }

        UiReferencer.Clear();
    }

    private void BuyWorker()
    {
        _summoner.Inventory.Gold -= 100;

        var miner = new Miner();

        var task = new Task(() => miner.Work());
        task.Start();

        _miners.Add(miner);
    }

    private List<string> ListWorkers()
    {
        var counter = 0;
        return _miners.Select(miner =>
        {
            var result = $"Miner Nr. {counter}";
            counter++;
            return result;
        }).ToList();
    }

    private Miner ParseMiner(string selected)
        => _miners.ElementAt(int.Parse(selected.Split(" ").Last()));
}
