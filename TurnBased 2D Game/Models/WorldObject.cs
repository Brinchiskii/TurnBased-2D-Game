using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased_2D_Game
{
    public class WorldObject
    {
        public string Name { get; set; }
        public bool Lootable { get; set; }
        public bool Removable { get; set; }

        public WorldObject(string name, bool lootable, bool removable)
        {
            this.Name = name;
            this.Lootable = lootable;
            this.Removable = removable;
        }
    }
}
