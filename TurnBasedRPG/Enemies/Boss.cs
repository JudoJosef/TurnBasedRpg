namespace TurnBasedRPG.Enemies
{
    public class Boss : IMonster
    {
        public int ExperienceToDrop { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Armor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MagicDefense { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Strength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
