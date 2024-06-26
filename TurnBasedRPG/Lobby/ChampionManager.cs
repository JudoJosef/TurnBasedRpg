﻿using TurnBasedRPG.Champions;
using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;
using static TurnBasedRPG.Constants;
using static TurnBasedRPG.Lobby.LobbyUtility;

namespace TurnBasedRPG.Lobby;

public class ChampionManager
{
    private Summoner _summoner;
    private Champion _selectedChampion = null!;
    private SummonerInventory _inventory = null!;
    private ChampionInventory _championInventory = null!;

    public ChampionManager(Summoner summoner)
    {
        _summoner = summoner;
        _inventory = _summoner.Inventory;
    }

    public void ShowItems(Champion selectedChamp)
    {
        _selectedChampion = selectedChamp;
        _championInventory = _selectedChampion.Inventory;
        var selected = string.Empty;

        while (selected != BackOption)
        {
            ShowEquippedItems();
            selected = UiReferencer.SelectSingle(AllItemTypes.Concat(new List<string> { BackOption }), SelectItemTypeCaption);
            if (selected != BackOption)
            {
                ShowItems(Enum.Parse<ItemTypes>(selected));
            }
        }
    }

    private void ShowItems(ItemTypes type)
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            selected = UiReferencer.SelectSingle(GetItems(type).Concat(new List<string> { BackOption }), SelectItemCaption);
            if (selected != BackOption)
            {
                ShowItem(selected, type);
            }
        }
    }

    private void ShowItem(string selected, ItemTypes type)
    {
        var selectedItem = GetItem(selected, _inventory.Items);
        UiReferencer.WriteItemTable(new List<Item> { selectedItem });

        var selectedOption = UiReferencer.SelectSingle(new List<string> { EquipOption, BackOption }, SelectOptionCaption);
        if (selectedOption == EquipOption)
        {
            EquipItem(selectedItem);
        }
    }

    private void EquipItem(Item selected)
    {
        var position = _championInventory.Items.Where(kvp => kvp.Key == selected.Type);
        if (position.Any())
        {
            var equippedItem = position.First().Value;

            _selectedChampion.UnEquipItem(equippedItem);
            _inventory.Items.Add(GetId(_inventory.Items.Keys.ToList()), equippedItem);
        }

        _selectedChampion.EquipItem(selected);
        _inventory.Items.Remove(_inventory.Items.Where(kvp => kvp.Value == selected).First().Key);
    }

    private List<string> GetItems(ItemTypes type)
        => _inventory.Items.Where(kvp =>
            kvp.Value.Type == type)
            .Select(kvp => $"#{kvp.Key} {kvp.Value.Name}")
            .ToList();

    private void ShowEquippedItems()
    {
        UiReferencer.Clear();
        UiReferencer.WriteLine(EquippedItemsCaption);
        if (_championInventory.Items.Any())
        {
            UiReferencer.WriteItemTable(_championInventory.Items.Values.ToList());
        }
        else
        {
            UiReferencer.WriteLine("None");
        }
    }
}
