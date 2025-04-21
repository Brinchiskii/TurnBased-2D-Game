using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased2DGame
{
    class DefenceItem : WorldObject
    {
        public string Name { get; set; }
        public int ReduceHitPoint { get; set; }
        
        public DefenceItem(string name, bool lootable, bool removable, int reduceHitPoint) : base(name, lootable, removable)
        {
            this.Name = name;
            this.ReduceHitPoint = reduceHitPoint;
        }
    }
}
