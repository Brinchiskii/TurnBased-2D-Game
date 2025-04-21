using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased2DGame
{
    public class World
    {
        private readonly List<Creature> _creatures;
        private readonly List<WorldObject> _worldObjects;
        
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

        public void AddCreature(Creature creature)
        {
            try
            {
                _creatures.Add(creature);
                Logger.Information($"Creature added({creature.Name}) to world");
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
        }
        
        public List<WorldObject> GetWorldObjects() => _worldObjects;

        public void AddWorldObject(WorldObject worldObject)
        {
            try
            {
                _worldObjects.Add(worldObject);
                Logger.Information($"WorldObject added({worldObject.Name}) to world");
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
        }
    }
}
