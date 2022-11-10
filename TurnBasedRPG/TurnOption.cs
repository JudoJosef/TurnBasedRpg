using TurnBasedRPG.Classes;

namespace TurnBasedRPG
{
    internal record TurnOption(ClassTypes Name, Func<Champion> Selected) : IOption;
}
