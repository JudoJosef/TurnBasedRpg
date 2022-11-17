using Spectre.Console;
using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Lobby
{
    public class Shop
    {
        private static List<Item> _items = new List<Item>();

        private static string _refreshOption = "Refresh (100)";
        private static string _backOption = "Back";
        private static string _sellOption = "Sell";
        private static string _buyOption = "Buy";

        private static string _notEnoughGoldMessage = "Not enough Gold.";

        public static void OpenShop(SummonerInventory inventory, int dungeonLevel)
        {
            string selected = string.Empty;

            while (selected != _backOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(new List<string> { _sellOption, _buyOption, _backOption }, "You have entered the shop.");
                if (selected == _sellOption)
                    Sell(inventory);
                else if (selected == _buyOption)
                    Buy(inventory, dungeonLevel);
            }
        }

        private static void Sell(SummonerInventory inventory)
        {
            string selected = string.Empty;

            while (selected != _backOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(inventory.Items.Select(kvp => $"#{kvp.Key} {kvp.Value.Name}").Concat(new List<string>{ "Back" }), "Select item to sell.");

                if (selected != _backOption)
                    TrySellItem(selected, inventory);
            }
        }

        private static void Buy(SummonerInventory inventory, int dungeonLevel)
        {
            if (_items.Count == 0)
                RefreshShop(dungeonLevel);

            string selected = string.Empty;

            while (selected != _backOption)
                selected = BuyItems(inventory, dungeonLevel);
        }

        private static string BuyItems(SummonerInventory inventory, int dungeonLevel)
        {
            Draw.Clear();
            Draw.WriteItemTable(_items);

            Draw.WriteLine($"Gold: {inventory.Gold}");

            var selected = Draw.SelectSingle(_items.Select(item => item.Name).Concat(new List<string> { _refreshOption, _backOption }), "Choose Item");

            if (selected != _refreshOption && selected != _backOption)
                TryBuyItem(selected, inventory);
            else if (selected == _refreshOption)
                TryRefresh(inventory, dungeonLevel);

            return selected;
        }

        private static void TryRefresh(SummonerInventory inventory, int dungeonLevel)
        {
            if (inventory.Gold >= 100)
            {
                inventory.Gold -= 100;
                RefreshShop(dungeonLevel);
            }
            else
                Draw.WriteLineAndWait(_notEnoughGoldMessage);
        }

        private static void TryBuyItem(string selected, SummonerInventory inventory)
        {
            var item = GetItem(selected);
            if (item.Price <= inventory.Gold)
                BuyItem(item, inventory);
            else
                Draw.WriteLineAndWait(_notEnoughGoldMessage);
        }

        private static void BuyItem(Item item, SummonerInventory inventory)
        {
            inventory.Items.Add(GetId(inventory.Items.Keys.ToList()), item);
            _items.Remove(item);
            inventory.Gold -= item.Price;
        }

        private static void TrySellItem(string selected, SummonerInventory inventory)
        {
            var selectedItem = GetItem(selected, inventory.Items);
            Draw.WriteItemTable(new List<Item> { selectedItem });
            selected = Draw.SelectSingle(new List<string> { _sellOption, _backOption }, "Select action.");

            if (selected == _sellOption)
            {
                inventory.Gold += selectedItem.Price;
                inventory.Items.Remove(inventory.Items.Where(kvp => kvp.Value == selectedItem).Single().Key);
            }
        }

        private static Item GetItem(string name)
            => _items.Where(item => item.Name == name)
                .Single();

        private static Item GetItem(string selected, Dictionary<int, Item> items)
            => items[int.Parse(
                selected.Split(" ")
                .First()
                .Replace("#", string.Empty))];

        private static int GetId(List<int> usedIds)
        {
            var availableId = -1;
            usedIds.ForEach(id =>
            {
                if (id >= availableId)
                    availableId = id + 1;
            });

            return availableId == -1
                ? 0
                : availableId;
        }

        private static void RefreshShop(int dungeonLevel)
        {
            _items.Clear();
            _items.Add(AddItem(dungeonLevel));
            _items.Add(AddItem(dungeonLevel));
            _items.Add(AddItem(dungeonLevel));
        }

        private static Item AddItem(int dungeonLevel)
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
