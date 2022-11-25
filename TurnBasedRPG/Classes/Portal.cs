using TurnBasedRPG.Classes.Skills;

namespace TurnBasedRPG.Classes
{
    public static class Portal
    {
        public static Champion SummonArcher()
            => new(
                400,
                30,
                30,
                30,
                ArcherSkills.GetSkills(),
                ClassTypes.Archer);

        public static Champion SummonAssassin()
            => new(
                420,
                35,
                30,
                70,
                AssassinSkills.GetSkills(),
                ClassTypes.Assassin);

        public static Champion SummonDryad()
            => new(
                500,
                30,
                40,
                25,
                DryadSkills.GetSkills(),
                ClassTypes.Dryad);

        public static Champion SummonFighter()
            => new(
                290,
                70,
                60,
                60,
                FighterSkills.GetSkills(),
                ClassTypes.Fighter);

        public static Champion CallJojo()
            => new(
                1100,
                110,
                110,
                90,
                JojoSkills.GetSkills(),
                ClassTypes.Jojo);

        public static Champion SummonMage()
            => new(
                430,
                35,
                65,
                30,
                MageSkills.GetSkills(),
                ClassTypes.Mage);

        public static Champion SummonPaladin()
            => new(
                1500,
                100,
                100,
                35,
                PaladinSkills.GetSkills(),
                ClassTypes.Paladin);

        public static Champion SummonSwordsman()
            => new(
                760,
                75,
                40,
                75,
                SwordsmanSkills.GetSkills(),
                ClassTypes.Swordsman);
    }
}
