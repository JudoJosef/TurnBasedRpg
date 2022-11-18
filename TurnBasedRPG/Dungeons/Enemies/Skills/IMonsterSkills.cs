namespace TurnBasedRPG.Dungeons.Enemies.Skills
{
    internal interface IMonsterSkills
    {
        static IEnumerable<Skill> GetSkills() => throw new NotImplementedException();

        static void UseFirstSkill(ICreature monster, List<ICreature> targets) => throw new NotImplementedException();

        static void UseSecondSkill(ICreature monster, List<ICreature> targets) => throw new NotImplementedException();

        static Skill GetFirstSkill() => throw new NotImplementedException();

        static Skill GetSecondSkill() => throw new NotImplementedException();
    }
}
