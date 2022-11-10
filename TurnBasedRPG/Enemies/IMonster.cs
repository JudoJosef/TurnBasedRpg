namespace TurnBasedRPG.Enemies
{
    internal interface IMonster : ICreature
    {
        int ExperienceToDrop { get; set; }
    }
}
