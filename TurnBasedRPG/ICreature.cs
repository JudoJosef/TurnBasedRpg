namespace TurnBasedRPG
{
    internal interface ICreature
    {
        double Health { get; set; }
        double Armor { get; set; }
        double MagicDefense { get; set; }
        double Strength { get; set; }

        IEnumerable<Skill> Skills { get; }

        void TurnAction(List<ICreature> creatures);
        void Attack(ICreature creature);
        void Defend();
        void UseSkill(List<ICreature> creatures);
    }
}
