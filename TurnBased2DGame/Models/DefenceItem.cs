using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased2DGame
{
    /// <summary>
    /// Representing the defence item in the game world
    /// </summary>
    public class DefenceItem : WorldObject
    {
        public string Name { get; set; }
        
        public int ReduceHitPoint { get; set; }

        public DefenceItem() : base()
        {
            
        }
        public DefenceItem(string name, bool lootable, bool removable, int reduceHitPoint) : base(name, lootable, removable)
        {
            this.Name = name;
            this.ReduceHitPoint = reduceHitPoint;
        }
        
        /// <summary>
        /// Extended method for creature looting a world object
        /// </summary>
        /// <param name="creature">The creature that wants to loot the item</param>
        public override void Loot(Creature creature)
        {
            creature.AddDefenceItem(this);
        }


        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(ReduceHitPoint)}: {ReduceHitPoint}";
        }
    }
}
