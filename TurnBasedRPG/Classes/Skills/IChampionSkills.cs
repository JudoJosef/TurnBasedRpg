namespace TurnBasedRPG.Classes.Skills
{
    internal interface IChampionSkills
    {
        static IEnumerable<Skill> GetSkills()=> throw new NotImplementedException();

        static void UseFirstSkill(Champion champion, List<ICreature> creatures) => throw new NotImplementedException();

        static void UseSecondSkill(Champion champion, List<ICreature> creatures) => throw new NotImplementedException();

        static void UseThirdSkill(Champion champion, List<ICreature> creatures) => throw new NotImplementedException();

        static Skill GetFirstSkill() => throw new NotImplementedException();

        static Skill GetSecondSkill() => throw new NotImplementedException();

        static Skill GetThirdSkill() => throw new NotImplementedException();
    }
}
