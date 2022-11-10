using TurnBasedRPG.Lobby;

namespace TurnBasedRPG.Classes
{
    internal interface IAlly : ICreature
    {
        double Experience { get; set; }
        ClassTypes Type { get; }
        ChampionInventory Inventory { get; set; }

        void LevelUp(Upgrade upgrade);

        Item EquipItem(Item item);
    }
}
