namespace TurnBasedRPG
{
    internal interface ICreature
    {
        int Health { get; set; }
        int Armor { get; set; }
        int MagicDefense { get; set; }
        int Strength { get; set; }

        IEnumerable<Skill> Skills { get; }

        void TurnAction(List<ICreature> creatures);
        void Attack(ICreature creature);
        void Defend();
        void UseSkill(List<ICreature> creatures);
    }
}
