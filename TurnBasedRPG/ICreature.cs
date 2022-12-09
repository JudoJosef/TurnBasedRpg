using TurnBasedRPG.Champions;

namespace TurnBasedRPG;

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

    void UseSkill(List<ICreature> creatures);

    void Die();
}
