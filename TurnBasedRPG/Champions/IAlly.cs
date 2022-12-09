using TurnBasedRPG.Lobby.Items;

namespace TurnBasedRPG.Champions;

public interface IAlly : ICreature
{
    int Shield { get; set; }

    int Experience { get; set; }

    int Level { get; set; }

    ClassTypes Type { get; }

    ChampionInventory Inventory { get; set; }

    void LevelUp();

    void EquipItem(Item item);
}
