using Spectre.Console;
using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;
using static TurnBasedRPG.Constants;
using static TurnBasedRPG.Lobby.LobbyUtility;

namespace TurnBasedRPG.Lobby
{
    public class Shop
    {
        private SummonerInventory _inventory;

        private static List<Item> _items = new List<Item>();

        private static string _notEnoughGoldMessage = "Not enough Gold.";

        public Shop(Summoner summoner)
        {
            _inventory = summoner.Inventory;
        }

        public void OpenShop(int dungeonLevel)
        {
            string selected = string.Empty;

            while (selected != BackOption)
            {
                UiReferencer.Clear();
                selected = UiReferencer.SelectSingle(new List<string> { SellOption, BuyOption, BackOption }, "You have entered the shop.");
                if (selected == SellOption)
                    Sell();
                else if (selected == BuyOption)
                    Buy(dungeonLevel);
            }
        }

        private void Sell()
        {
            string selected = string.Empty;

            while (selected != BackOption)
            {
                UiReferencer.Clear();
                selected = UiReferencer.SelectSingle(_inventory.Items.Select(kvp => $"#{kvp.Key} {kvp.Value.Name}").Concat(new List<string>{ BackOption }), "Select item to sell.");

                if (selected != BackOption)
                    TrySellItem(selected);
            }
        }

        private void Buy(int dungeonLevel)
        {
            if (_items.Count == 0)
                RefreshShop(dungeonLevel);

            string selected = string.Empty;

            while (selected != BackOption)
                selected = BuyItems(dungeonLevel);
        }

        private string BuyItems(int dungeonLevel)
        {
            UiReferencer.Clear();
            UiReferencer.WriteItemTable(_items);

            UiReferencer.WriteLine($"Gold: {_inventory.Gold}");

            var selected = UiReferencer.SelectSingle(_items.Select(item => item.Name).Concat(new List<string> { RefreshOption, BackOption }), "Choose Item");

            if (selected != RefreshOption && selected != BackOption)
                TryBuyItem(selected);
            else if (selected == RefreshOption)
                TryRefresh(dungeonLevel);

            return selected;
        }

        private void TryRefresh(int dungeonLevel)
        {
            if (_inventory.Gold >= 100)
            {
                _inventory.Gold -= 100;
                RefreshShop(dungeonLevel);
            }
            else
                UiReferencer.WriteLineAndWait(_notEnoughGoldMessage);
        }

        private void TryBuyItem(string selected)
        {
            var item = GetItem(selected);
            if (item.Price <= _inventory.Gold)
                BuyItem(item);
            else
                UiReferencer.WriteLineAndWait(_notEnoughGoldMessage);
        }

        private void BuyItem(Item item)
        {
            _inventory.Items.Add(GetId(_inventory.Items.Keys.ToList()), item);
            _items.Remove(item);
            _inventory.Gold -= item.Price;
        }

        private void TrySellItem(string selected)
        {
            var selectedItem = LobbyUtility.GetItem(selected, _inventory.Items);
            UiReferencer.WriteItemTable(new List<Item> { selectedItem });
            selected = UiReferencer.SelectSingle(new List<string> { SellOption, BackOption }, "Select action.");

            if (selected == SellOption)
            {
                _inventory.Gold += selectedItem.Price;
                _inventory.Items.Remove(_inventory.Items.Where(kvp => kvp.Value == selectedItem).Single().Key);
            }
        }

        private Item GetItem(string name)
            => _items.Where(item => item.Name == name)
                .Single();

        private void RefreshShop(int dungeonLevel)
        {
            _items.Clear();
            _items.Add(AddItem(dungeonLevel));
            _items.Add(AddItem(dungeonLevel));
            _items.Add(AddItem(dungeonLevel));
        }

        private Item AddItem(int dungeonLevel)
        {
            var contains = false;
            Item? newItem = null;

            do
            {
                newItem = ItemFactory.GetItem(dungeonLevel);
                contains = _items.Select(item => item.Name == newItem.Name).Contains(true);
            } while (contains);

            return newItem ?? throw new Exception();
        }
    }
}
