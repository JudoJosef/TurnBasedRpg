using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Lobby
{
    internal class Forge
    {
        public static void EnterForge(Summoner summoner)
        {
            string selected = string.Empty;

            while (selected != _backOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(new List<string> { _upgradeOption, _craftOption, _backOption }, "You have entered the forge.");
                if (selected == _upgradeOption)
                    Upgrade(summoner);
                else if (selected == _craftOption)
                    Craft(summoner.Inventory);
            }
        }

        private static void Upgrade(Summoner summoner)
        {
            string selected = string.Empty;

            while (selected != _backOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(GetItems(summoner).Concat(new List<string> { _backOption }), "Select item to upgrade.");
                if (selected != _backOption)
                    TryUpgrade(selected, summoner.Inventory);
            }
        }
        private static void TryUpgrade(string selected, SummonerInventory inventory)
        {
            var item = GetItem(selected);

            while (selected != _backOption)
            {
                var cost = GetRarityPrice(item.Rarity.ToString());
                Draw.Clear();
                Draw.WriteItemTable(new List<Item> { item });
                Draw.WriteLine($"Upgrade cost: {cost}");

                selected = Draw.SelectSingle(new List<string> { _upgradeOption, _backOption }, string.Empty);
                if (selected != _backOption)
                    Upgrade(item, inventory, cost);
            }
        }

        private static List<string> GetItems(Summoner summoner)
        {
            var counter = 0;
            _allItems.Clear();

            summoner.Champions.SelectMany(champion =>
                champion.Inventory.Items.Values)
                .Concat(summoner.Inventory.Items.Values)
                .ToList()
                .ForEach(item =>
                {
                    _allItems.Add(counter, item);
                    counter++;
                });

            return _allItems.Select(kvp => $"#{kvp.Key} {kvp.Value.Name}").ToList();
        }

        private static Item GetItem(string selected)
            => _allItems.Where(kvp =>
                kvp.Key == int.Parse(
                    selected.Split(" ")
                    .First()
                    .Replace("#", string.Empty)))
                .First().Value;

        private static void Upgrade(Item item, SummonerInventory inventory, int price)
        {
            if (inventory.Gold >= price)
            {
                item.Upgrade();
                inventory.Gold -= price;
            }
            else
            {
                Draw.WriteLineAndWait("Not enough gold.");
            }
        }

        private static int GetRarityPrice(string selected)
            => Enum.Parse<CraftingCost>(selected) switch
            {
                CraftingCost.Common => (int)CraftingCost.Common,
                CraftingCost.Uncommon => (int)CraftingCost.Uncommon,
                CraftingCost.Rare => (int)CraftingCost.Rare,
                CraftingCost.Epic => (int)CraftingCost.Epic,
                CraftingCost.Legendary => (int)CraftingCost.Legendary,
                CraftingCost.Mythic => (int)CraftingCost.Mythic,
                _ => throw new Exception(),
            };

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
    }
}
