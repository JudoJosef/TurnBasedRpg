using TurnBasedRPG.Champions;
using static TurnBasedRPG.Constants;

namespace TurnBasedRPG.Lobby;

public class ChampionInspector
{
    private Champion _selectedChampion = null!;
    private ChampionManager _manager = null!;

    private List<Champion> _starterChampions = new List<Champion>();
    private List<Champion> _availableChampions = new List<Champion>();

    public void SetManager(ChampionManager manager)
        => _manager = manager;

    public List<Champion> SelectChampions(List<Champion> champions)
    {
        _availableChampions = champions;

        while (_starterChampions.Count() != 3)
        {
            ShowChampions(new List<string> { AbilitiesOption, SelectOption, BackOption }, new List<string>());
        }

        return _starterChampions;
    }

    public void ShowChampions(List<Champion> champions, List<string> options)
    {
        _availableChampions = champions;
        var selected = string.Empty;

        do
        {
            selected = ShowChampions(options, new List<string> { BackOption });
        }
        while (selected != BackOption);
    }

    private string ShowChampions(List<string> options, List<string> additional)
    {
        UiReferencer.Clear();
        var selected = UiReferencer.SelectSingle(
            _availableChampions.Select(champion => champion.Type.ToString())
            .Concat(additional),
            SelectChampionCaption);

        if (selected != BackOption)
        {
            GetChampion(selected, _availableChampions);
            ShowChampion(options);
        }

        return selected;
    }

    private void ShowChampion(List<string> options)
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            UiReferencer.Clear();
            UiReferencer.WriteChampionStatTable(new List<Champion> { _selectedChampion });
            selected = UiReferencer.SelectSingle(options, SelectActionCaption);

            if (selected == ItemsOption)
            {
                _manager.ShowItems(_selectedChampion);
            }
            else if (selected == AbilitiesOption)
            {
                ShowAbilities();
            }
            else if (selected == SelectOption)
            {
                SelectChampion();
                selected = BackOption;
            }
        }
    }

    private void SelectChampion()
    {
        _starterChampions.Add(_selectedChampion);
        GetChoices(_availableChampions)
            .ForEach(champion =>
                _availableChampions.Remove(champion));
    }

    private void ShowAbilities()
    {
        var selected = string.Empty;

        while (selected != BackOption)
        {
            UiReferencer.Clear();
            selected = UiReferencer.SelectSingle(_selectedChampion.Skills.Select(skill => skill.Name).Concat(new List<string> { BackOption }), SelectSkillCaption);

            if (selected != BackOption)
            {
                ShowDescription(selected);
            }
        }
    }

    private void ShowDescription(string selected)
    {
        var skill = _selectedChampion.Skills.Where(skill => skill.Name == selected).First();

        UiReferencer.WriteLineAndWait($"{skill.Name}\n{skill.Description}");
    }

    private void GetChampion(string selected, List<Champion> champions)
        => _selectedChampion = champions.Where(champion => champion.Type == Enum.Parse<ClassTypes>(selected)).First();

    private List<Champion> GetChoices(List<Champion> current)
        => current.Where(champion =>
            _starterChampions.Select(sc =>
                sc.Type != champion.Type).Contains(false))
            .ToList();
}
