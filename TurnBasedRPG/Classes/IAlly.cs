using TurnBasedRPG.Lobby.Items;

namespace TurnBasedRPG.Classes
{
    public interface IAlly : ICreature
    {
        int Shield { get; set; }
        double Experience { get; set; }
        ClassTypes Type { get; }
        ChampionInventory Inventory { get; set; }

        void LevelUp(Upgrade upgrade);

        void EquipItem(Item item);
    }
}
