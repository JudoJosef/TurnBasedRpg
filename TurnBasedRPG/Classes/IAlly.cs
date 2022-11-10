namespace TurnBasedRPG.Classes
{
    internal interface IAlly : ICreature
    {
        double Experience { get; set; }
        ClassTypes Type { get; }

        void LevelUp(Upgrade upgrade);
    }
}
