using TurnBasedRPG.Classes;
using TurnBasedRPG.Dungeons.Enemies;
using TurnBasedRPG.Lobby.Items;
using static TurnBasedRPG.Lobby.Constants;

namespace TurnBasedRPG.Dungeons
{
    public class GameHandler
    {
        public static void TickDebuff(List<Debuff> debuffs, ICreature creature)
        {
            debuffs.Where(debuff => debuff.RoundAmount > 0)
                .ToList()
                .ForEach(debuff => debuff.Execute(creature));
            debuffs.ForEach(debuff => debuff.RoundAmount--);
            debuffs.Where(debuff => debuff.RoundAmount <= 0)
                .ToList()
                .ForEach(debuff => debuffs.Remove(debuff));
        }

        public static ICreature GetAlly(List<ICreature> creatures)
        {
            Draw.WriteChampionStatTable(creatures.Cast<Champion>().ToList());
            var target = Draw.SelectSingle(creatures.Select(creature => ((Champion)creature).Type.ToString()), "Select ally");
            return creatures.Where(creature => ((Champion)creature).Type == Enum.Parse<ClassTypes>(target)).First();
        }

        public static ICreature GetAttackTarget(List<ICreature> creatures)
        {
            var target = Draw.SelectSingle(
                ParseToSelection(creatures)
                .Concat(new List<string> { BackOption }),
                "Select target");

            if (target == BackOption)
            {
                Dungeon.Used = false;
                return null!;
            }

            return creatures.ElementAt(int.Parse(target.Split(" ").First().Replace("#", string.Empty)) - 1);
        }

        public static ICreature GetTarget(List<ICreature> creatures)
        {
            var target = Draw.SelectSingle(ParseToSelection(creatures), "Select target");
            return creatures.ElementAt(int.Parse(target.Split(" ").First().Replace("#", string.Empty)) - 1);
        }

        public static ICreature GetRandomTarget(List<ICreature> creatures)
            => creatures.ElementAt(new Random().Next(0,creatures.Count()));

        public static void StealItem(ICreature creature)
        {
            var items = ((Champion)creature).Inventory.Items;
            var rnd = new Random();

            if (items.Any())
            {
                while (true)
                {
                    var key = (ItemTypes)(rnd.Next(0, 6));
                    if (items.ContainsKey(key))
                    {
                        items.Remove(key);
                        break;
                    }
                }
            }
        }

        public static void SetCooldown(ICreature user, int index)
            => user.Skills.ElementAt(index).ActualCooldown = user.Skills.ElementAt(index).Cooldown;

        public static void Revive(ICreature target)
            => target.Health = target.MaxHealth / 2;

        public static void HealAllies(List<ICreature> targets)
            => targets.ForEach(target => HealCreature(target, (target.MaxHealth - target.Health) / 4));

        public static void HealCreature(ICreature creature, int amount)
            => creature.Health += amount;

        public static void DealPhysicalDamage(ICreature target, int damage)
        {
            if (target is IAlly ally)
            {
                var postDamage = GetReducedDamage(target.Armor, damage);
                if (ally.Shield > 0 && ally.Shield - postDamage > 0)
                {
                    ally.Shield -= postDamage;
                }
                else
                {
                    postDamage -= ally.Shield;
                    ally.Shield = 0;
                    ally.Health -= postDamage;
                }
            }
            else
            {
                target.Health -= GetReducedDamage(target.Armor, damage);
            }
        }

        public static void DealMagicDamage(ICreature target, int damage)
        {
            if (target is IAlly ally)
            {
                var postDamage = GetReducedDamage(target.MagicDefense, damage);
                if (ally.Shield > 0 && ally.Shield - postDamage > 0)
                {
                    ally.Shield -= postDamage;
                }
                else
                {
                    postDamage -= ally.Shield;
                    ally.Shield = 0;
                    ally.Health -= postDamage;
                }
            }
            else
            {
                target.Health -= GetReducedDamage(target.MagicDefense, damage);
            }
        }

        public static void DealTrueDamage(ICreature target, int damage)
            => target.Health -= damage;

        public static void GiveShield(List<ICreature> recievers, int amount)
            => recievers.ForEach(reciever => ((Champion)reciever).Shield += amount);

        public static void GiveArmor(List<ICreature> recievers, int amount)
            => recievers.ForEach(reciever => ((Champion)reciever).Armor += amount);

        public static void AddDebuffs(List<ICreature> targets, int damage, int rounds)
            => targets.ForEach(target => AddDebuff(target, damage, rounds));

        public static void AddDebuff(ICreature target, int damage, int rounds)
            => target.Debuffs.Add(new Debuff(rounds, 
                target =>
                {
                    DealMagicDamage(target, damage);
                    rounds--;
                }));

        private static int GetReducedDamage(int armor, int damage)
            => damage / (1 + (armor / 100));

        private static IEnumerable<string> ParseToSelection(IEnumerable<ICreature> creatures)
        {
            var counter = 0;

            foreach(var creature in creatures)
            {
                counter++;
                yield return $"#{counter} {((IMonster)creature).Type}";
            }
        }
    }
}
