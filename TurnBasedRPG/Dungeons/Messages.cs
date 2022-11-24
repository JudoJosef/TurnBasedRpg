namespace TurnBasedRPG.Dungeons
{
    public class Messages
    {
        public static Func<ICreature, ICreature, string> DamageTarget =
            (creature, target) => $"{creature} has attacked {target}";

        public static Func<ICreature, ICreature, string> HealTarget =
            (creature, target) => $"{creature} has healed {target}";

        public static Func<ICreature, string> ReviveTarget =
            (target) => $"{target} has been revived";

        public static Func<ICreature, ICreature, string, string> UseSingleTargetSkill =
            (creature, target, skillname) => $"{creature} has used {skillname} against {target}";

        public static Func<ICreature, string, string> UseAOESkill =
            (creature, skillname) => $"{creature} has used {skillname}";

        public static Func<ICreature, string> Defeated =
            (creature) => $"{creature} has been defeated";

        public static Func<ICreature, string> IncreaseStats =
            (creature) => $"The stats of {creature} have been increased";

        public static Func<ICreature, ICreature, int, string> DebuffTarget =
            (creature, target, rounds) => $"{creature} has debuffed {target} for {rounds} rounds";

        public static Func<ICreature, ICreature, string> StealItem =
            (creature, target) => $"{creature} has an item from {target}";

        public static Func<ICreature, string> GetShield =
            (creature) => $"{creature} has recieved a shield";
    }
}
