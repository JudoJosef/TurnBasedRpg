namespace TurnBasedRPG.Database
{
    public class TypeTranslator
    {
        public static readonly IReadOnlyDictionary<Type, string> AllTypes = new Dictionary<Type, string>
        {
            { typeof(long), "INTEGER" },
            { typeof(string), "TEXT" },
            { typeof(bool), "BOOLEAN" },
        };
    }
}
