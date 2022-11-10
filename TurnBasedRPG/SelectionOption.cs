using TurnBasedRPG.Classes;

namespace TurnBasedRPG
{
    internal record SelectionOption(ClassTypes Name, Action Selected) : IOption;
}
