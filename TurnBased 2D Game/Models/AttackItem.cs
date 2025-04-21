using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased_2D_Game
{
    class AttackItem : WorldObject
    {
        public string Name { get; set; }
        public int Hit { get; set; }
        public int Range { get; set; }

        public AttackItem(string name, bool lootable, bool removable, int hit, int range) : base(name, lootable, removable)
        {
            this.Name = name;
            this.Hit = hit;
            this.Range = range;
        }
    }
}
