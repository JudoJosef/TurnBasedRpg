using TurnBasedRPG.Player;
using static TurnBasedRPG.Constants;

namespace TurnBasedRPG.Lobby
{
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
                    new List<string> { "Monsters", "Bosses", BackOption },
                    "Select category");

                if (selected == "Monsters")
                    ShowMonsters();
                else if (selected == "Bosses")
                    ShowBosses();
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
                    "Select monster");

                if (selected != BackOption)
                    ShowCreature(selected);
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
                    "Select boss");

                if (selected != BackOption)
                    ShowCreature(selected);
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
                    $"{type}\nSelect Ability");

                if (selected != BackOption)
                    UiReferencer.WriteLineAndWait(
                        creature.Skills.Where(skill => skill.Name == selected)
                        .Single().Description);
            }
        }
    }
}
