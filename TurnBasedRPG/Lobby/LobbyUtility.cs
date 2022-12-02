using TurnBasedRPG.Lobby.Items;

namespace TurnBasedRPG.Lobby
{
    public class LobbyUtility
    {
        public static int GetRarityCraftingPrice(string selected)
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

        public static int GetRarityPrice(string selected)
            => Enum.Parse<CraftingCost>(selected) switch
            {
                CraftingCost.Common => (int)ItemPrice.Common,
                CraftingCost.Uncommon => (int)ItemPrice.Uncommon,
                CraftingCost.Rare => (int)ItemPrice.Rare,
                CraftingCost.Epic => (int)ItemPrice.Epic,
                CraftingCost.Legendary => (int)ItemPrice.Legendary,
                CraftingCost.Mythic => (int)ItemPrice.Mythic,
                _ => throw new Exception(),
            };

        public static int GetId(List<int> usedIds)
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

        public static Item GetItem(string selected, Dictionary<int, Item> items)
            => items[int.Parse(
                selected.Split(" ")
                .First()
                .Replace("#", string.Empty))];
    }
}
