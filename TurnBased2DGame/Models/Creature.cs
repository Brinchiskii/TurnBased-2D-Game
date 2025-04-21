using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased2DGame
{
    /// <summary>
    /// Representing the living creature in the world
    /// </summary>
    public class Creature
    {
        private readonly List<AttackItem> _attackItems;
        private readonly List<DefenceItem> _defenceItems;
        
        public string Name { get; set; }
        public int HitPoint { get; set; }

        public Creature()
        {
            _attackItems = new List<AttackItem>();
            _defenceItems = new List<DefenceItem>();
        }
        
        public Creature(string name, int hitPoint)
        {
            Name = name;
            HitPoint = hitPoint;
            
            _attackItems = new List<AttackItem>();
            _defenceItems = new List<DefenceItem>();
        }

        /// <summary>
        /// Total hit points this creature can deal from all its attack items.
        /// </summary>
        /// <returns>The total attack value</returns>
        public int Hit()
        {
            if (_attackItems.Count == 0)
            {
                return 0;
            }

            int totalHit = _attackItems.Sum(item => item.Hit);
            return totalHit;
        }

        /// <summary>
        /// The total received hit from an attack
        /// </summary>
        /// <param name="hit">The total hit value</param>
        public void ReceiveHit(int hit)
        {
            int totalDefence = _defenceItems.Sum(item => item.ReduceHitPoint);
            int finalDamage = Math.Max(0, hit - totalDefence);
            
            HitPoint -= finalDamage;

            Logger.Information($"{Name} received hit, {hit} damage, (after {totalDefence} defence). Remaining HP: {HitPoint}");
            
            if (HitPoint < 0)
            {
                Logger.Information($"{Name} is defeated!");
            }
        }

        /// <summary>
        /// Adds loot to the associated inventory of the creature
        /// </summary>
        /// <param name="worldObject">The picked up world object</param>
        public void Loot(WorldObject worldObject)
        {
            if (!worldObject.Lootable)
            {
                Logger.Information($"{Name} tried to loot '{worldObject.Name}', but it is not lootable.");
                return;
            }

            switch (worldObject)
            {
                case AttackItem attackItem:
                    _attackItems.Add(attackItem);
                    Logger.Information($"{Name} looted AttackItem '{attackItem.Name}' (Hit: {attackItem.Hit})");
                    break;
                case DefenceItem defenceItem:
                    _defenceItems.Add(defenceItem);
                    Logger.Information($"{Name} looted DefenceItem '{defenceItem.Name}' (Defense: {defenceItem.ReduceHitPoint})");
                    break;
                
                default:
                    Logger.Information($"{Name} looted unknown object '{worldObject.Name}'");
                    break;
            }
        }

        public override string ToString()
        {
            return
                $"{nameof(Name)}: {Name}, {nameof(HitPoint)}: {HitPoint}";
        }
    }
}
