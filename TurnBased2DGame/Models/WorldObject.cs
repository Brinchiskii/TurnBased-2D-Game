using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased2DGame
{
    /// <summary>
    /// Represents the basic data that should be in every world object
    /// </summary>
    public abstract class WorldObject
    {
        public string Name { get; set; }
        public bool Lootable { get; set; }
        public bool Removable { get; set; }

        public WorldObject()
        {
            
        }
        
        public WorldObject(string name, bool lootable, bool removable)
        {
            Name = name;
            Lootable = lootable;
            Removable = removable;
        }
        
        /// <summary>
        /// Extension method for creature to loot world objects
        /// </summary>
        /// <param name="creature">The Creature that want to loot the item</param>
        public abstract void Loot(Creature creature);
    }
}
