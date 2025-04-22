using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBased2DGame.Interfaces;

namespace TurnBased2DGame
{
    /// <summary>
    /// Representing the world in the game
    /// </summary>
    public class World
    {
        private readonly List<Creature> _creatures;
        private readonly List<WorldObject> _worldObjects;
        private readonly IWorldNotifier? _notifier;
        
        public int MaxX { get; set; }
        public int MaxY { get; set; }
        public string GameLevel { get; set; }

        public World(int maxX, int maxY, string gameLevel, IWorldNotifier? notifier = null)
        {
            MaxX = maxX;
            MaxY = maxY;
            GameLevel = gameLevel;
            _notifier = notifier;
            _creatures = new List<Creature>();
            _worldObjects = new List<WorldObject>();
        }
        
        /// <summary>
        /// Getting all the creatures in the world
        /// </summary>
        /// <returns>A list of all creatures</returns>
        public List<Creature> GetCreatures() => _creatures;

        /// <summary>
        /// Adds creatures to the world by populating the creature list
        /// </summary>
        /// <param name="creature">Creature object which needs to be added to the world</param>
        public void AddCreature(Creature creature)
        {
            try
            {
                _creatures.Add(creature); 
                _notifier?.OnWorldAddCreature(creature);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
        }
        
        /// <summary>
        /// Getting all the world objects in the world
        /// </summary>
        /// <returns>A list of all world objects</returns>
        public List<WorldObject> GetWorldObjects() => _worldObjects;

        /// <summary>
        /// Adds world objects to the world by populating the worldObjects list
        /// </summary>
        /// <param name="worldObject">World object which needs to be added to the world</param>
        public void AddWorldObject(WorldObject worldObject)
        {
            try
            {
                _worldObjects.Add(worldObject); 
                _notifier?.OnWorldAddWorldObject(worldObject);
            }
            catch (Exception e)
            {
                Logger.Error(e.Message);
                throw;
            }
        }
    }
}
