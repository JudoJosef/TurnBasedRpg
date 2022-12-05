using Spectre.Console;
using TurnBasedRPG.Classes;
using TurnBasedRPG.Dungeons.Enemies;
using TurnBasedRPG.Lobby.Items;
using TurnBasedRPG.Player;

namespace TurnBasedRPG
{
    public static class UiReferencer
    {
        public static string SelectSingle(IEnumerable<string> options, string title)
            => Draw.SelectSingle(options, title);

        public static string GetLine(string line)
            => Draw.GetLine(line);

        public static void Clear()
            => Draw.Clear();

        public static void WriteLine(string line)
            => Draw.WriteLine(line);

        public static void WriteLineAndWait(string line)
            => Draw.WriteLineAndWait(line);

        public static void WriteLootTable(ItemRarity rarity, SummonerInventory inventory, int craftingCost)
            => Draw.WriteLootTable(rarity, inventory, craftingCost);

        public static void WriteItemTable(List<Item> items)
            => Draw.WriteItemTable(items);

        public static void WriteChampionStatTable(List<Champion> champions)
            => Draw.WriteChampionStatTable(champions);

        public static void WriteChampionFightStatTable(List<Champion> champions)
            => Draw.WriteChampionFightStatTable(champions);

        public static void WriteMonsterStatTable(List<ICreature> creatures)
            => Draw.WriteMonsterStatTable(creatures);
    }
}
