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

        internal static Champion SummonAssassin()
            => new(
                80,
                20,
                10,
                70,
                AssassinSkills.GetSkills(),
                ClassTypes.Assassin);

        internal static Champion SummonDryad()
            => new(
                100,
                25,
                20,
                25,
                DryadSkills.GetSkills(),
                ClassTypes.Dryad);
    }
}
