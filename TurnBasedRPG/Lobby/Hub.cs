﻿using TurnBasedRPG.Dungeons;
using TurnBasedRPG.Player;
using static TurnBasedRPG.Constants;

namespace TurnBasedRPG.Lobby;

public class Hub
{
    private readonly Summoner _summoner;
    private readonly Forge _forge;
    private readonly Shop _shop;
    private readonly ChampionInspector _inspector;
    private readonly Dungeon _dungeon;
    private readonly Altar _altar;
    private readonly BookOfMonsters _bookOfMonsters;
    private readonly Mine _mine;

    public Hub(Summoner summoner, ChampionInspector inspector)
    {
        _summoner = summoner;
        _forge = new Forge(_summoner);
        _shop = new Shop(_summoner);
        _inspector = inspector;
        _inspector.SetManager(new ChampionManager(_summoner));
        _dungeon = new Dungeon(_summoner);
        _altar = new Altar(_summoner);
        _bookOfMonsters = new BookOfMonsters(_summoner);
        _mine = new Mine(_summoner);
    }

    public void EnterLobby()
    {
        while (true)
        {
            UiReferencer.Clear();
            var selected = UiReferencer.SelectSingle(
                new List<string>
                {
                    ForgeOption,
                    ShopOption,
                    ChampionsOption,
                    AltarOption,
                    MineOption,
                    BookOfMonstersOption,
                    DungeonOption,
                    ExitOption,
                },
                SelectOptionCaption);

            Execute(selected);
        }
    }

    private void Execute(string selected)
    {
        switch (selected)
        {
            case ForgeOption:
                _forge.EnterForge();
                break;
            case ShopOption:
                _shop.OpenShop(_dungeon.DungeonLevel);
                break;
            case ChampionsOption:
                _inspector.ShowChampions(_summoner.Champions, new List<string> { ItemsOption, AbilitiesOption, BackOption });
                break;
            case DungeonOption:
                _dungeon.EnterDungeon();
                break;
            case AltarOption:
                _altar.Open();
                break;
            case BookOfMonstersOption:
                _bookOfMonsters.Open();
                break;
            case MineOption:
                _mine.Open();
                break;
            case ExitOption:
                Environment.Exit(0);
                break;
        }
    }
}
