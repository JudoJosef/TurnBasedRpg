using TurnBasedRPG.Classes;
using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG.Lobby
{
    internal class ChampionManager
    {
        private static readonly IEnumerable<string> _itemTypes = new List<string>
        {
            ItemTypes.Helmet.ToString(),
            ItemTypes.Chestplate.ToString(),
            ItemTypes.Leggins.ToString(),
            ItemTypes.Boots.ToString(),
            ItemTypes.Weapon.ToString(),
            ItemTypes.Accessoire.ToString(),
        };

        public static void ShowChampions(Summoner summoner)
        {
            var selected = string.Empty;

            while (selected != "Back")
            {
                selected = Draw.SelectSingle(
                    summoner.Champions.Select(champion => champion.Type.ToString())
                    .Concat(new List<string> { "Back" }),
                    "Select champion.");

                if (selected != "Back")
                    ShowChampion(GetChampion(summoner, selected), summoner);
            }
        }

        private static void ShowChampion(Champion champion, Summoner summoner)
        {
            var selected = string.Empty;

            while (selected != "Back")
            {
                Draw.Clear();
                Draw.WriteChampionStatTable(champion);
                selected = Draw.SelectSingle(new List<string> { "Items", "Abilities", "Back" },
                    "Select action.");

                if (selected == "Items")
                    ShowItems(champion, summoner);
                else if (selected == "Abilities")
                    ShowAbilities(champion);
            }
        }

        private static void ShowAbilities(Champion champion)
        {
            var selected = string.Empty;

            while (selected != "Back")
            {
                Draw.Clear();
                selected = Draw.SelectSingle(champion.Skills.Select(skill => skill.Name).Concat(new List<string> { "Back" }), "Select ability:");

                if (selected != "Back")
                    ShowDescrption(selected, champion);
            }
        }

        private static void ShowItems(Champion champion, Summoner summoner)
        {
            var selected = string.Empty;

            while (selected != "Back")
            {
                selected = Draw.SelectSingle(_itemTypes.Concat(new List<string> { "Back" }), "Select item type");
                if (selected != "Back")
                    ShowItems(champion, Enum.Parse<ItemTypes>(selected), summoner);
            }
        }

        private static void ShowItems(Champion champion, ItemTypes type, Summoner summoner)
        {
            var selected = string.Empty;

            while (selected != "Back")
            {
                Draw.Clear();
                Item item = null!;
                Draw.WriteLine("Equpped item:");
                if (champion.Inventory.Items.Where(item => item.Key == type).Any())
                {
                    item = champion.Inventory.Items.Where(item => item.Key == type).ToList().First().Value;
                    Draw.WriteItemTable(new List<Item> { item });
                }

                selected = Draw.SelectSingle(GetItems(summoner, type).Concat(new List<string> { "Back" }), "Select item:");
                if (selected != "Back")
                    ShowItem(selected, item, champion, summoner, type);
            }
        }

        private static void ShowItem(string selected, Item item, Champion champion, Summoner summoner, ItemTypes type)
        {
            Draw.Clear();
            if (item is not null)
            {
                item = champion.Inventory.Items.Where(item => item.Key == type).ToList().First().Value;
                Draw.WriteItemTable(new List<Item> { item });
            }

            var selectedItem = GetItem(selected, summoner);
            Draw.WriteItemTable(new List<Item> { selectedItem });

            var selectedOption = Draw.SelectSingle(new List<string> { "Equip", "Back" }, "Select option");
            if (selectedOption == "Equip")
                EquipItem(selectedItem, champion, summoner);
        }
        }

        private static void ShowDescrption(string selected, Champion champion)
        {
            var skill = champion.Skills.Where(skill => skill.Name == selected).First();

            Draw.WriteLineAndWait($"{skill.Name}\n{skill.Description}");
        }

        private static Champion GetChampion(Summoner summoner, string selected)
            => summoner.Champions.Where(champion => champion.Type == Enum.Parse<ClassTypes>(selected)).First();

        private static List<string> GetItems(Summoner summoner, ItemTypes type)
            => summoner.Inventory.Items.Where(kvp =>
                kvp.Value.Type == type)
                .Select(kvp => $"#{kvp.Key} {kvp.Value.Name}")
                .ToList();

        private static Item GetItem(string selected, Summoner summoner)
            => summoner.Inventory.Items.Where(kvp =>
                kvp.Key == int.Parse(
                    selected.Split(" ")
                    .First()
                    .Replace("#", string.Empty)))
                .First()
                .Value;

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
