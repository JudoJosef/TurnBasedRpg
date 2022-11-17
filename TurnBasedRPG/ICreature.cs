using TurnBasedRPG.Classes;

namespace TurnBasedRPG
{
    public interface ICreature
    {
        int Health { get; set; }
        int MaxHealth { get; set; }
        int Armor { get; set; }
        int MagicDefense { get; set; }
        int Strength { get; set; }

        List<Skill> Skills { get; }
        List<Debuff> Debuffs { get; set; }

        void TurnAction(List<ICreature> creatures);
        void Attack(ICreature creature);
        void Defend();
        void UseSkill(List<ICreature> creatures);
    }
}
