using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Selection
{
    internal record SelectionOption(ClassTypes Name, Action Selected) : IOption;
}
