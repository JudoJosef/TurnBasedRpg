using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;
using static TurnBasedRPG.Lobby.Constants;
using static TurnBasedRPG.Lobby.LobbyUtility;

namespace TurnBasedRPG.Lobby
{
    public class Forge
    {
        private Summoner _summoner;
        private SummonerInventory _inventory;

        private Dictionary<int, Item> _allItems = new Dictionary<int, Item>();

        public Forge(Summoner summoner)
        {
            _summoner = summoner;
            _inventory = summoner.Inventory;
        }

        public void EnterForge()
        {
            string selected = string.Empty;

            while (selected != BackOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(new List<string> { UpgradeOption, CraftOption, BackOption }, "You have entered the forge.");
                if (selected == UpgradeOption)
                    Upgrade();
                else if (selected == CraftOption)
                    Craft();
            }
        }

        private void Upgrade()
        {
            string selected = string.Empty;

            while (selected != BackOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(GetItems().Concat(new List<string> { BackOption }), "Select item to upgrade.");
                if (selected != BackOption)
                    TryUpgrade(selected);
            }
        }

        private void Craft()
        {
            string selected = string.Empty;

            while (selected != BackOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(AllRarities.Concat(new List<string> { BackOption }), "Select rarity.");
                if (selected != BackOption)
                    TryCraft(selected);
            }
        }

        private void TryCraft(string rarity)
        {
            var cost = GetRarityPrice(rarity);

            string selected = string.Empty;

            while (selected != BackOption)
            {
                Draw.WriteLootTable(Enum.Parse<ItemRarity>(rarity), _inventory, cost);

                selected = Draw.SelectSingle(new List<string> { CraftOption, BackOption }, string.Empty);
                if (selected != BackOption)
                    Craft(rarity, cost);
            }
        }

        private void TryUpgrade(string selected)
        {
            var item = GetItem(selected, _allItems);

            while (selected != BackOption)
            {
                var cost = (int)(GetRarityPrice(item.Rarity.ToString()) * GetMultiplicator(item.Level));
                Draw.Clear();
                Draw.WriteItemTable(new List<Item> { item });
                Draw.WriteLine($"Upgrade cost: {_inventory.Gold}/{cost}");

                selected = Draw.SelectSingle(new List<string> { UpgradeOption, BackOption }, string.Empty);
                if (selected != BackOption)
                    Upgrade(item, cost);
            }
        }

        private List<string> GetItems()
        {
            var counter = 0;
            _allItems.Clear();

            _summoner.Champions.SelectMany(champion =>
                champion.Inventory.Items.Values)
                .Concat(_inventory.Items.Values)
                .ToList()
                .ForEach(item =>
                {
                    _allItems.Add(counter, item);
                    counter++;
                });

            return _allItems.Select(kvp => $"#{kvp.Key} {kvp.Value.Name}").ToList();
        }

        private void Upgrade(Item item, int price)
        {
            if (_inventory.Gold >= price)
            {
                item.Upgrade();
                _inventory.Gold -= price;
            }
            else
            {
                Draw.WriteLineAndWait("Not enough gold.");
            }
        }

        private void Craft(string rarity, int cost)
        {
            if (!_inventory.Loot.Values.Select(loot => loot.Value >= cost).Contains(false))
            {
                _inventory.Loot.Values.ToList().ForEach(loot => loot.Value -= cost);
                var item = ItemFactory.GetItem(Enum.Parse<ItemRarity>(rarity));
                Draw.Clear();
                _inventory.Items.Add(GetId(_inventory.Items.Keys.ToList()), item);
                Draw.WriteItemTable(new List<Item> { item });
                Draw.WriteLineAndWait(string.Empty);
                Draw.Clear();
            }
            else
            {
                Draw.WriteLineAndWait("Not enough materials.");
            }
        }

        private double GetMultiplicator(int itemLevel)
            => ((double)(itemLevel -1) / 4) + 1;
    }
}
