namespace TurnBasedRPG.Classes.Skills
{
    public interface IChampionSkills
    {
        static IEnumerable<Skill> GetSkills() => throw new NotImplementedException();

        static void UseFirstSkill(ICreature champion, List<ICreature> creatures) => throw new NotImplementedException();

        static void UseSecondSkill(ICreature champion, List<ICreature> creatures) => throw new NotImplementedException();

        static void UseThirdSkill(ICreature champion, List<ICreature> creatures) => throw new NotImplementedException();

        static Skill GetFirstSkill() => throw new NotImplementedException();

        static Skill GetSecondSkill() => throw new NotImplementedException();

        static Skill GetThirdSkill() => throw new NotImplementedException();
    }
}
