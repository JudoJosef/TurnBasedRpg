namespace TurnBasedRPG.Lobby
{
    internal class Shop
    {
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
    }
}
