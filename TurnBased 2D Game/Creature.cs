using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased_2D_Game
{
    class Creature
    {
        private List<AttackItem> _attackItems;
        private List<DefenceItem> _defenceItems;
        
        public string Name { get; set; }
        public int HitPoint { get; set; }

        public Creature()
        {
            _attackItems = new List<AttackItem>();
            _defenceItems = new List<DefenceItem>();
        }

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
