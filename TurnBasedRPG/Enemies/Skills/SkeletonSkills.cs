namespace TurnBasedRPG.Enemies.Skills
{
    internal class SkeletonSkills : IMonsterSkills
    {
        public static IEnumerable<Skill> GetSkills()
            => new List<Skill>
            {
                GetFirstSkill(),
                GetSecondSkill(),
            };

        public static void UseFirstSkill(ICreature monster, List<ICreature> targets)
        {
        }

        public static void UseSecondSkill(ICreature monster, List<ICreature> targets)
        {
        }

        private static Skill GetFirstSkill()
            => new Skill("Bone throw", 3, UseFirstSkill, Descriptions.Skeleton.FirstSkill);

        private static Skill GetSecondSkill()
            => new Skill("Skeletal curse", 7, UseSecondSkill, Descriptions.Skeleton.SecondSkill);
    }
}
