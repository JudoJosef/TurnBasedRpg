using TurnBasedRPG.Classes;
using TurnBasedRPG.Selection;

namespace TurnBasedRPG
{
    internal record TurnOption(ClassTypes Name, Func<Champion> Selected) : IOption;
}
