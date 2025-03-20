using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased_2D_Game
{
    class Creature
    {
        public string Name { get; set; }
        public int HitPoint { get; set; }

        public int Hit()
        {
            throw new NotImplementedException();
        }

        public void ReceiveHit(int hit)
        {
            throw new NotImplementedException();
        }

        public void Loot(WorldObject worldObject)
        {
            throw new NotImplementedException();
        }
    }
}
