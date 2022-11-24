namespace TurnBasedRPG.Dungeons.Enemies
{
    public interface IMonster : ICreature
    {
        int ExperienceToDrop { get; set; }
        EnemyTypes Type { get; }
    }
}
