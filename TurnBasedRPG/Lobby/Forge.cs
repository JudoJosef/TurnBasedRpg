using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Lobby
{
    internal class Forge
    {
        private static string _backOption = "Back";
        private static string _craftOption = "Craft";
        private static string _upgradeOption = "Upgrade";

        private static Dictionary<int, Item> _allItems = new Dictionary<int, Item>();

        public static List<LootTypes> AllLootTypes = new List<LootTypes>
        {
            LootTypes.Leather,
            LootTypes.Scales,
            LootTypes.Orcteeth,
            LootTypes.Scrap,
            LootTypes.Silk,
        };

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

        private static void Craft(SummonerInventory inventory)
        {
            string selected = string.Empty;

            while (selected != _backOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(GetRarities().Concat(new List<string> { _backOption }), "Select rarity.");
                if (selected != _backOption)
                    TryCraft(selected, inventory);
            }
        }

        private static void TryCraft(string rarity, SummonerInventory inventory)
        {
            var cost = GetRarityPrice(rarity);

            string selected = string.Empty;

            while (selected != _backOption)
            {
                Draw.WriteLootTable(Enum.Parse<ItemRarity>(rarity), inventory, cost);

                selected = Draw.SelectSingle(new List<string> { _craftOption, _backOption }, string.Empty);
                if (selected != _backOption)
                    Craft(rarity, inventory, cost);
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

        private static void Craft(string rarity, SummonerInventory inventory, int cost)
        {
            if (!inventory.Loot.Values.Select(loot => loot.Value >= cost).Contains(false))
            {
                inventory.Loot.Values.ToList().ForEach(loot => loot.Value -= cost);
                var item = ItemFactory.GetItem(Enum.Parse<ItemRarity>(rarity));
                Draw.Clear();
                inventory.Items.Add(GetId(inventory.Items.Keys.ToList()), item);
                Draw.WriteItemTable(new List<Item> { item });
                Draw.WriteLineAndWait(string.Empty);
                Draw.Clear();
            }
            else
            {
                Draw.WriteLineAndWait("Not enough materials.");
            }
        }

        private static List<string> GetRarities()
            => new List<string>
            {
                ItemRarity.Common.ToString(),
                ItemRarity.Uncommon.ToString(),
                ItemRarity.Rare.ToString(),
                ItemRarity.Epic.ToString(),
                ItemRarity.Legendary.ToString(),
                ItemRarity.Mythic.ToString(),
            };

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
