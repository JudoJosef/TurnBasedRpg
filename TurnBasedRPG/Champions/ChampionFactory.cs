﻿using TurnBasedRPG.Champions.Skills;

namespace TurnBasedRPG.Champions;

public static class ChampionFactory
{
    public static List<Champion> SummonChampions()
        => new List<Champion>
        {
            SummonArcher(),
            SummonAssassin(),
            SummonDryad(),
            SummonFighter(),
            SummonMage(),
            SummonPaladin(),
            SummonSwordsman(),
        };

    public static List<Skill> GetSkillSet(ClassTypes type)
        => type switch
        {
            ClassTypes.Assassin => AssassinSkills.GetSkills(),
            ClassTypes.Archer => ArcherSkills.GetSkills(),
            ClassTypes.Dryad => DryadSkills.GetSkills(),
            ClassTypes.Paladin => PaladinSkills.GetSkills(),
            ClassTypes.Swordsman => SwordsmanSkills.GetSkills(),
            ClassTypes.Jojo => JojoSkills.GetSkills(),
            ClassTypes.Mage => MageSkills.GetSkills(),
            ClassTypes.Fighter => FighterSkills.GetSkills(),
            _ => throw new NotImplementedException(),
        };

    public static Champion CallJojo()
        => new(
            1100,
            110,
            110,
            150,
            JojoSkills.GetSkills(),
            ClassTypes.Jojo);

    private static Champion SummonArcher()
        => new(
            650,
            45,
            40,
            60,
            ArcherSkills.GetSkills(),
            ClassTypes.Archer);

    private static Champion SummonAssassin()
        => new(
            690,
            45,
            40,
            105,
            AssassinSkills.GetSkills(),
            ClassTypes.Assassin);

    private static Champion SummonDryad()
        => new(
            950,
            40,
            60,
            40,
            DryadSkills.GetSkills(),
            ClassTypes.Dryad);

    private static Champion SummonFighter()
        => new(
            700,
            70,
            60,
            90,
            FighterSkills.GetSkills(),
            ClassTypes.Fighter);

    private static Champion SummonMage()
        => new(
            630,
            40,
            65,
            65,
            MageSkills.GetSkills(),
            ClassTypes.Mage);

    private static Champion SummonPaladin()
        => new(
            1500,
            120,
            120,
            55,
            PaladinSkills.GetSkills(),
            ClassTypes.Paladin);

    private static Champion SummonSwordsman()
        => new(
            800,
            90,
            55,
            80,
            SwordsmanSkills.GetSkills(),
            ClassTypes.Swordsman);
}
