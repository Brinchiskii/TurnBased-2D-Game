using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased2DGame
{
    public class World
    {
        private List<Creature> _creatures;
        private List<WorldObject> _worldObjects;
        
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public string GameLevel { get; set; }

        public World(int maxX, int maxY, string gameLevel)
        {
            MaxX = maxX;
            MaxY = maxY;
            GameLevel = gameLevel;
            
            _creatures = new List<Creature>();
            _worldObjects = new List<WorldObject>();
        }
        
        public List<Creature> GetCreatures() => _creatures;
        
        public void AddCreature(Creature creature) => _creatures.Add(creature);
        
        public List<WorldObject> GetWorldObjects() => _worldObjects;
        
        public void AddWorldObject(WorldObject worldObject) => _worldObjects.Add(worldObject);
    }
}
