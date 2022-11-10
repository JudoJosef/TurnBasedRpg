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

        internal static Champion SummonFighter()
            => new(
                140,
                40,
                30,
                60,
                FighterSkills.GetSkills(),
                ClassTypes.Fighter);

        internal static Champion CallJojo()
            => new(
                200,
                50,
                50,
                90,
                JojoSkills.GetSkills(),
                ClassTypes.Jojo);

        internal static Champion SummonMage()
            => new(
                80,
                25,
                40,
                30,
                MageSkills.GetSkills(),
                ClassTypes.Mage);

        internal static Champion SummonPaladin()
            => new(
                400,
                65,
                65,
                35,
                PaladinSkills.GetSkills(),
                ClassTypes.Paladin);
    }
}
