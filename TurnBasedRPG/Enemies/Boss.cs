namespace TurnBasedRPG.Enemies
{
    internal class Boss : IMonster
    {
        public int ExperienceToDrop { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Armor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double MagicDefense { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double Strength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<Skill> Skills => throw new NotImplementedException();

        public void Attack(ICreature creature)
        {
            throw new NotImplementedException();
        }

        public void Defend()
        {
            throw new NotImplementedException();
        }

        public void TurnAction(List<ICreature> creatures)
        {
            throw new NotImplementedException();
        }

        public void UseSkill(List<ICreature> creatures)
        {
            throw new NotImplementedException();
        }
    }
}
