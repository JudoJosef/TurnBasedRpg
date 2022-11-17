namespace TurnBasedRPG.Classes
{
    public class Debuff
    {
        public Debuff(int roundAmount, Action<ICreature> execute)
        {
            RoundAmount = roundAmount;
            Execute = execute;
        }

        public int RoundAmount { get; set; }
        public Action<ICreature> Execute { get; set; }
    }
}
