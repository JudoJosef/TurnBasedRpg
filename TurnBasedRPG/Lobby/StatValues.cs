namespace TurnBasedRPG.Lobby
{
    internal class StatValues
    {
        public static int[] HealthStats =
        {
            new Random().Next(10, 25),
            new Random().Next(15, 40),
            new Random().Next(20, 50),
            new Random().Next(40, 75),
            new Random().Next(90, 170),
            new Random().Next(250, 600),
        };

        public static int[] PhysicalDefenseStats =
        {
            new Random().Next(1, 4),
            new Random().Next(3, 7),
            new Random().Next(6, 11),
            new Random().Next(13, 19),
            new Random().Next(15, 25),
            new Random().Next(40, 67),
        };

        public static int[] MagicDefenseStats =
        {
            new Random().Next(1, 4),
            new Random().Next(3, 7),
            new Random().Next(6, 11),
            new Random().Next(13, 19),
            new Random().Next(15, 25),
            new Random().Next(40, 67),
        };

        public static int[] StrengthStats =
        {
            new Random().Next(10, 19),
            new Random().Next(15, 32),
            new Random().Next(20, 50),
            new Random().Next(40, 75),
            new Random().Next(90, 170),
            new Random().Next(110, 270),
        };

        public static int[] Prices=
        {
            35,
            60,
            95,
            160,
            250,
            400,
        };
    }
}
