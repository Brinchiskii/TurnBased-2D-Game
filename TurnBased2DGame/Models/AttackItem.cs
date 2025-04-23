using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased2DGame
{
    /// <summary>
    /// Representing the attack item in the game world
    /// </summary>
    public class AttackItem : WorldObject
    {
        public string Name { get; set; }

        public int Hit { get; set; }
        public int Range { get; set; }

        public AttackItem() : base()
        {
            
        }
        
        public AttackItem(string name, bool lootable, bool removable, int hit, int range) : base(name, lootable, removable)
        {
            this.Name = name;
            this.Hit = hit;
            this.Range = range;
        }

        /// <summary>
        /// Extended method for creature looting a world object
        /// </summary>
        /// <param name="creature">The creature that wants to loot the item</param>
        public override void Loot(Creature creature)
        {
            creature.AddAttackItem(this);
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Hit)}: {Hit}, {nameof(Range)}: {Range}";
        }
    }
}
