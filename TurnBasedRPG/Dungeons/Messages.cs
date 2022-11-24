namespace TurnBasedRPG.Dungeons
{
    public class Messages
    {
        public static Func<Enum, Enum, string> DamageTarget =
            (creature, target) => $"{creature} has attacked {target}";

        public static Func<Enum, Enum, string> HealTarget =
            (creature, target) => $"{creature} has healed {target}";

        public static Func<Enum, string> ReviveTarget =
            (target) => $"{target} has been revived";

        public static Func<Enum, Enum, string, string> UseSingleTargetSkill =
            (creature, target, skillname) => $"{creature} has used {skillname} against {target}";

        public static Func<Enum, string, string> UseAOESkill =
            (creature, skillname) => $"{creature} has used {skillname}";

        public static Func<Enum, string> Defeated =
            (creature) => $"{creature} has been defeated";

        public static Func<Enum, string> IncreaseStats =
            (creature) => $"The stats of {creature} have been increased";

        public static Func<Enum, Enum, int, string> DebuffTarget =
            (creature, target, rounds) => $"{creature} has debuffed {target} for {rounds} rounds";

        public static Func<Enum, Enum, string> StealItem =
            (creature, target) => $"{creature} has an item from {target}";

        public static Func<Enum, string> GetShield =
            (creature) => $"{creature} has recieved a shield";
    }
}
