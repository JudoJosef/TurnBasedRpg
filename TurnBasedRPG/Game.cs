using TurnBasedRPG.Classes;
using TurnBasedRPG.Enemies;
using TurnBasedRPG.Lobby;
using TurnBasedRPG.Player;

namespace TurnBasedRPG
{
    public class Game
    {
        private Summoner _summoner = CreateSummoner();
        private List<IMonster> _monsters = new List<IMonster>();
        private List<ICreature> _creatures = new List<ICreature>();

        public void Run()
        {
            var lobby = new Hub(_summoner);
            lobby.EnterLobby();
            StartFight();
        }

        private void StartFight()
        {
            do
            {
                PlayerTurn();
            } while (_summoner.Champions.Where(champion => champion.Health <= 0).Count() == 3);
        }

        private void PlayerTurn()
        {
            var usedChamps = new List<Champion>();
            var usableChampions = GetUsableChampions(usedChamps);

            for (int i = 0; i < usableChampions.Count; i++)
            {
                GetCreatures();

                var selectedChampion = GetChampion(Draw.SelectSingle(ParseToString(usableChampions), "Select champion"));
                selectedChampion.TurnAction(_creatures);

                usedChamps.Add(selectedChampion);
                usableChampions.Clear();
                usableChampions.AddRange(GetUsableChampions(usedChamps));
            }
        }

        private List<Champion> GetUsableChampions(List<Champion> usedChamps)
            => _summoner.Champions.Where(champion =>
                champion.Health > 0
                && !usedChamps.Contains(champion)).ToList();

        private static List<Champion> GetChampions()
            => Draw.SelectChampions()
                .Select(type => ParseToClassType(type))
                .Select(championType => SummonChampion(championType))
                .ToList();

        private void GetCreatures()
        {
            _creatures.Clear();
            _creatures.AddRange(_summoner.Champions);
            _creatures.AddRange(_monsters);
        }

        private static Summoner CreateSummoner()
            => new Summoner(GetChampions(), new SummonerInventory());

        private static Champion SummonChampion(ClassTypes type)
            => type switch
            {
                ClassTypes.Archer => Portal.SummonArcher(),
                ClassTypes.Assassin => Portal.SummonAssassin(),
                ClassTypes.Dryad => Portal.SummonDryad(),
                ClassTypes.Fighter => Portal.SummonFighter(),
                ClassTypes.Jojo => Portal.CallJojo(),
                ClassTypes.Mage => Portal.SummonMage(),
                ClassTypes.Paladin => Portal.SummonPaladin(),
                ClassTypes.Swordsman => Portal.SummonSwordsman(),
                _ => throw new NotImplementedException()
            };

        private Champion GetChampion(string type)
            => _summoner.Champions.Where(champion =>
                champion.Type == ParseToClassType(type))
                .Single();

        private static ClassTypes ParseToClassType(string type)
            => Enum.Parse<ClassTypes>(type);

        private List<string> ParseToString(List<Champion> champions)
            => champions.Select(champion => champion.Type.ToString()).ToList();
    }
}
