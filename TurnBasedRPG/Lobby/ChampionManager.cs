using TurnBasedRPG.Classes;
using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;
using static TurnBasedRPG.Lobby.Constants;
using static TurnBasedRPG.Lobby.LobbyUtility;

namespace TurnBasedRPG.Lobby
{
    public class ChampionManager
    {
        private Summoner _summoner;
        private Champion _selectedChampion = null!;

        public ChampionManager(Summoner summoner)
        {
            _summoner = summoner;
        }

        public void ShowChampions()
        {
            var selected = string.Empty;

            while (selected != BackOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(
                    _summoner.Champions.Select(champion => champion.Type.ToString())
                    .Concat(new List<string> { BackOption }),
                    "Select champion.");

                if (selected != BackOption)
                    GetChampion(selected);
                    ShowChampion();
            }
        }

        private void ShowChampion()
        {
            var selected = string.Empty;

            while (selected != BackOption)
            {
                Draw.Clear();
                Draw.WriteChampionStatTable(_selectedChampion);
                selected = Draw.SelectSingle(new List<string> { ItemsOption, AbilitiesOption, BackOption },
                    "Select action.");

                if (selected == ItemsOption)
                    ShowItems();
                else if (selected == AbilitiesOption)
                    ShowAbilities();
            }
        }

        private void ShowAbilities()
        {
            var selected = string.Empty;

            while (selected != BackOption)
            {
                Draw.Clear();
                selected = Draw.SelectSingle(_selectedChampion.Skills.Select(skill => skill.Name).Concat(new List<string> { BackOption }), "Select ability:");

                if (selected != BackOption)
                    ShowDescrption(selected);
            }
        }

        private void ShowItems()
        {
            var selected = string.Empty;

            while (selected != BackOption)
            {
                selected = Draw.SelectSingle(AllItemTypes.Concat(new List<string> { BackOption }), "Select item type");
                if (selected != BackOption)
                    ShowItems(Enum.Parse<ItemTypes>(selected));
            }
        }

        private void ShowItems(ItemTypes type)
        {
            var selected = string.Empty;

            while (selected != BackOption)
            {
                Draw.Clear();
                Item item = null!;
                Draw.WriteLine("Equpped item:");
                if (_selectedChampion.Inventory.Items.Where(item => item.Key == type).Any())
                {
                    item = _selectedChampion.Inventory.Items.Where(item => item.Key == type).ToList().First().Value;
                    Draw.WriteItemTable(new List<Item> { item });
                }

                selected = Draw.SelectSingle(GetItems(type).Concat(new List<string> { BackOption }), "Select item:");
                if (selected != BackOption)
                    ShowItem(selected, item, type);
            }
        }

        private void ShowItem(string selected, Item item, ItemTypes type)
        {
            Draw.Clear();
            if (item is not null)
            {
                item = _selectedChampion.Inventory.Items.Where(item => item.Key == type).ToList().First().Value;
                Draw.WriteItemTable(new List<Item> { item });
            }

            var selectedItem = GetItem(selected, _summoner.Inventory.Items);
            Draw.WriteItemTable(new List<Item> { selectedItem });

            var selectedOption = Draw.SelectSingle(new List<string> { EquipOption, BackOption }, "Select option");
            if (selectedOption == EquipOption)
                EquipItem(selectedItem);
        }

        private void EquipItem(Item selected)
        {
            var position = _selectedChampion.Inventory.Items.Where(kvp => kvp.Key == selected.Type);
            if (position.Any())
            {
                var equippedItem = position.First().Value;
                _selectedChampion.Inventory.Items.Remove(selected.Type);
                _summoner.Inventory.Items.Add(GetId(_summoner.Inventory.Items.Keys.ToList()), equippedItem);
            }
            _selectedChampion.Inventory.Items.Add(selected.Type, selected);
            _summoner.Inventory.Items.Remove(_summoner.Inventory.Items.Where(kvp => kvp.Value == selected).First().Key);
        }

        private void ShowDescrption(string selected)
        {
            var skill = _selectedChampion.Skills.Where(skill => skill.Name == selected).First();

            Draw.WriteLineAndWait($"{skill.Name}\n{skill.Description}");
        }

        private void GetChampion(string selected)
            => _selectedChampion = _summoner.Champions.Where(champion => champion.Type == Enum.Parse<ClassTypes>(selected)).First();

        private List<string> GetItems(ItemTypes type)
            => _summoner.Inventory.Items.Where(kvp =>
                kvp.Value.Type == type)
                .Select(kvp => $"#{kvp.Key} {kvp.Value.Name}")
                .ToList();
    }
}
