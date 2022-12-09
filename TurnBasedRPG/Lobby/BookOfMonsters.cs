using TurnBasedRPG.Player;
using static TurnBasedRPG.Constants;

namespace TurnBasedRPG.Lobby;

public class BookOfMonsters
{
    private Summoner _summoner;

    public BookOfMonsters(Summoner summoner)
    {
        _summoner = summoner;
    }

    public void Open()
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            selected = UiReferencer.SelectSingle(
                new List<string> { MonstersOption, BossesOption, BackOption },
                SelectCategoryCaption);

            if (selected == MonstersOption)
            {
                ShowMonsters();
            }
            else if (selected == BossesOption)
            {
                ShowBosses();
            }
        }
    }

    private void ShowMonsters()
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            selected = UiReferencer.SelectSingle(
                _summoner.DefeatedCreatures.Where(creature =>
                    (int)creature.Type < 30)
                .Select(monster =>
                    monster.Type.ToString())
                .Concat(new List<string> { BackOption }),
                SelectMonsterCaption);

            if (selected != BackOption)
            {
                ShowCreature(selected);
            }
        }
    }

    private void ShowBosses()
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            selected = UiReferencer.SelectSingle(
                _summoner.DefeatedCreatures.Where(creature =>
                    (int)creature.Type > 29)
                .Select(monster =>
                    monster.Type.ToString())
                .Concat(new List<string> { BackOption }),
                SelectBossCaption);

            if (selected != BackOption)
            {
                ShowCreature(selected);
            }
        }
    }

    private void ShowCreature(string type)
    {
        var creature = _summoner.DefeatedCreatures.Where(creature => creature.Type.ToString() == type).Single();

        var selected = string.Empty;

        while (selected != BackOption)
        {
            UiReferencer.Clear();
            selected = UiReferencer.SelectSingle(
                creature.Skills.Select(skill => skill.Name)
                .Concat(new List<string> { BackOption }),
                $"{type}\n{SelectSkillCaption}");

            if (selected != BackOption)
            {
                UiReferencer.WriteLineAndWait(
                    creature.Skills.Where(skill => skill.Name == selected)
                    .Single().Description);
            }
        }
    }
}
