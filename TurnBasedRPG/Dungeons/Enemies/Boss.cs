using TurnBasedRPG.Classes;

namespace TurnBasedRPG.Dungeons.Enemies
{
    public class Boss : IMonster
    {
        public int ExperienceToDrop { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MaxHealth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Armor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int MagicDefense { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Strength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public EnemyTypes Type { get => throw new NotImplementedException(); }

        public List<Skill> Skills => throw new NotImplementedException();
        public List<Debuff> Debuffs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Attack(ICreature creature)
        {
            throw new NotImplementedException();
        }

        public void Die()
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
