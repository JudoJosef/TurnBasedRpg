namespace TurnBasedRPG.Dungeons.Enemies.Skills;

internal class Descriptions
{
    public static class Goblin
    {
        public const string FirstSkill = "The goblin jumps at one enemy and deals a certain amount of damage";
        public const string SecondSkill = "The goblin steals a random item from one of the champions";
    }

    public static class Skeleton
    {
        public const string FirstSkill = "The skeleton throws a bone at one of the champions";
        public const string SecondSkill = "The skeleton curses one of the champions, dealing damage over time";
    }

    public static class Zombie
    {
        public const string FirstSkill = "The zombie throws his hands at the champions dealing damage to all of them";
        public const string SecondSkill = "The zombie has a small chance of reviving itself";
    }

    public static class Giant
    {
        public const string FirstSkill = "The giant smashes the ground dealing damage to one of the champions";
        public const string SecondSkill = "The giant jumps, creating a shockwave that damages all champions";
    }

    public static class Griffin
    {
        public const string FirstSkill = "The griffin grabs one of the champions and drops him on the ground, dealing a small amount of damage";
        public const string SecondSkill = "The griffin creates a whirlwind by waving his wings and damages all champions";
    }

    public static class Wolfpack
    {
        public const string FirstSkill = "The wolfpack deals a small amount of damage to a single champion";
        public const string SecondSkill = "The wolfpack howls and permanently increases their attack damage";
    }

    public static class Basilisk
    {
        public const string FirstSkill = "The basilisk produces an acid breath that deals damage over time to all champions";
        public const string SecondSkill = "The basilisk turnes one of the champions to stone dealing a large amount of damage";
    }

    public static class Dragon
    {
        public const string FirstSkill = "The dragon starts breathing fire and damages all champions";
        public const string SecondSkill = "The dragon creates a pool of lava under the champions, dealing a heavy amount of damage to all of them";
    }

    public static class Cyclops
    {
        public const string FirstSkill = "The cyclops mashes a champion with his club, dealing a heavy amount of damage";
        public const string SecondSkill = "The cyclops summons a heard of sheeps that deal damage to all champions";
    }

    public static class Tarantula
    {
        public const string FirstSkill = "The tarantula bites a champion and deals damage over time";
        public const string SecondSkill = "The tarantula covers one of the champions in webs and deals magic damage";
    }

    // Bosses
    public static class Amon
    {
        public const string FirstSkill = "Amon deals damage to all champions";
        public const string SecondSkill = "Amon heavily increases his stats";
        public const string ThirdSkill = "Amon deals an immense amount of damage to a single target";
    }

    public static class ModernTalking
    {
        public const string FirstSkill = "Modern talking plays the worst song in existence and damages all champions over time";
        public const string SecondSkill = "Modern talking sings loudly and increases their strength";
        public const string ThirdSkill = "Modern talking calls brother louie to buff their defense stats";
    }

    public static class DemonKing
    {
        public const string FirstSkill = "The demon king shoots a dark beam at one target and deals an immense amount of damage";
        public const string SecondSkill = "The demon king deals damage over time to all champions";
        public const string ThirdSkill = "The demon king deals 100% current health damage to all champions and heals himself for the dealt amount";
    }

    public static class SoulEater
    {
        public const string FirstSkill = "The soul eater deals a large amount of magic damage to a single target";
        public const string SecondSkill = "The soul eater increases his stats";
        public const string ThirdSkill = "The soul eater deals 100% of the targets health as damage and heals himself for the actual dealt damage";
    }

    public static class GhostSamurai
    {
        public const string FirstSkill = "The ghost samurai uses quickdraw on one target and deals a large amount of damage";
        public const string SecondSkill = "The ghost samurai covers a large area in a thick mist and permanently deceases the strength of every champion";
        public const string ThirdSkill = "The ghost samurai gains an immense amount of strength. You lost";
    }
}
