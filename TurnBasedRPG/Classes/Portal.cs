using TurnBasedRPG.Classes.Skills;

namespace TurnBasedRPG.Classes
{
    public static class Portal
    {
        public static Champion SummonArcher()
            => new(
                70,
                20,
                10,
                30,
                ArcherSkills.GetSkills(),
                ClassTypes.Archer);

        public static Champion SummonAssassin()
            => new(
                80,
                20,
                10,
                70,
                AssassinSkills.GetSkills(),
                ClassTypes.Assassin);

        public static Champion SummonDryad()
            => new(
                100,
                25,
                20,
                25,
                DryadSkills.GetSkills(),
                ClassTypes.Dryad);

        public static Champion SummonFighter()
            => new(
                140,
                40,
                30,
                60,
                FighterSkills.GetSkills(),
                ClassTypes.Fighter);

        public static Champion CallJojo()
            => new(
                200,
                50,
                50,
                90,
                JojoSkills.GetSkills(),
                ClassTypes.Jojo);

        public static Champion SummonMage()
            => new(
                80,
                25,
                40,
                30,
                MageSkills.GetSkills(),
                ClassTypes.Mage);

        public static Champion SummonPaladin()
            => new(
                400,
                65,
                65,
                35,
                PaladinSkills.GetSkills(),
                ClassTypes.Paladin);

        public static Champion SummonSwordsman()
            => new(
                210,
                45,
                20,
                75,
                SwordsmanSkills.GetSkills(),
                ClassTypes.Swordsman);
    }
}
