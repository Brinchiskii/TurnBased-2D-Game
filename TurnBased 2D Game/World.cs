using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased_2D_Game
{
    class World
    {
        private List<Creature> _creatures;
        private List<WorldObject> _worldObjects;
        
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public World()
        {
            _creatures = new List<Creature>();
            _worldObjects = new List<WorldObject>();
        }
    }
}
