using TurnBasedRPG.Classes;
using TurnBasedRPG.Classes.Skills;

namespace TurnBasedRPG
{
    internal static class Portal
    {
        internal static Champion SummonArcher()
            => new(
                70,
                20,
                10,
                30,
                ArcherSkills.GetSkills(),
                ClassTypes.Archer);
    }
}
