using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBased2DGame.Interfaces;

namespace TurnBased2DGame
{
    /// <summary>
    /// Representing the living creature in the world
    /// </summary>
    public class Creature
    {
        private readonly List<AttackItem> _attackItems;
        private readonly List<DefenceItem> _defenceItems;
        private readonly ICreatureNotifier? _notifier;
        
        public string Name { get; set; }
        public int HitPoint { get; set; }

        public Creature()
        {
            _attackItems = new List<AttackItem>();
            _defenceItems = new List<DefenceItem>();
        }
        
        public Creature(string name, int hitPoint, ICreatureNotifier? notifier = null)
        {
            Name = name;
            HitPoint = hitPoint;
            _notifier = notifier;
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

            _notifier?.OnCreatureHit(this, hit, finalDamage);
            
            if (HitPoint < 0)
            {
                _notifier?.OnCreatureDefeated(this);
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
                _notifier?.OnCreatureLootingFailed(this, worldObject);
                return;
            }

            switch (worldObject)
            {
                case AttackItem attackItem:
                    _attackItems.Add(attackItem);
                    _notifier?.OnCreatureLooting(this, attackItem);
                    break;
                case DefenceItem defenceItem:
                    _defenceItems.Add(defenceItem);
                    _notifier?.OnCreatureLooting(this, defenceItem);
                    break;
                
                default:
                    _notifier?.OnCreatureLooting(this, worldObject);
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
