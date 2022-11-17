namespace TurnBasedRPG.Enemies
{
    public interface IMonster : ICreature
    {
        int ExperienceToDrop { get; set; }
    }
}
