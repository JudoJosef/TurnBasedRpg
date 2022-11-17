using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBasedRPG.Dungeons
{
    public class GameHandler
    {
        public static void DealPhysicalDamage(ICreature user, ICreature target, int damage)
            => target.Health -= GetReducedDamage(target.Armor, damage);

        private static int GetReducedDamage(int armor, int damage)
            => damage / (1 + (armor / 100));
    }
}
