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
    public abstract class Creature
    {
        private readonly List<AttackItem> _attackItems;
        private readonly List<DefenceItem> _defenceItems;
        private readonly ICreatureNotifier? _notifier;
        
        public string Name { get; set; }
        public int HitPoint { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Creature()
        {
            _attackItems = new List<AttackItem>();
            _defenceItems = new List<DefenceItem>();
        }
        
        public Creature(int x, int y, string name, int hitPoint, ICreatureNotifier? notifier = null)
        {
            X = x;
            Y = y;
            Name = name;
            HitPoint = hitPoint;
            _notifier = notifier;
            _attackItems = new List<AttackItem>();
            _defenceItems = new List<DefenceItem>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void TakeTurn(Creature target)
        {
            Prepare();
            ExecuteTurn(target);
            EndTurn();
        }

        /// <summary>
        /// Method for creature preparing before its turn
        /// </summary>
        protected virtual void Prepare()
        {
            _notifier?.OnCreaturePreparingTurn(this);
        }

        /// <summary>
        /// Method for executing fight
        /// </summary>
        protected abstract void ExecuteTurn(Creature target);

        /// <summary>
        /// Method for creature ending the turn
        /// </summary>
        protected virtual void EndTurn()
        {
            _notifier?.OnCreatureEndingTurn(this);
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
            
            _notifier?.OnCreatureMoved(this);
        }

        public void Attack(Creature target)
        {
            int damage = Hit();
            _notifier?.OnCreatureAttack(this, target, damage);
            target.ReceiveHit(damage);
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
        /// Adds attack item to the creatures inventory
        /// </summary>
        /// <param name="item">The item that needs to be added</param>
        public void AddAttackItem(AttackItem item)
        {
            try
            {
                _attackItems.Add(item);
                _notifier?.OnCreatureLooting(this, item);
            }
            catch (Exception e)
            {
                _notifier?.OnCreatureLootingFailed(this, item);
                throw;
            }
        }

        /// <summary>
        /// Adds defence item to the creatures inventory
        /// </summary>
        /// <param name="item">The item that needs to be added</param>
        public void AddDefenceItem(DefenceItem item)
        {
            try
            {
                _defenceItems.Add(item);
                _notifier?.OnCreatureLooting(this, item);
            }
            catch (Exception e)
            {
                _notifier?.OnCreatureLootingFailed(this, item);
                throw;
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

            worldObject.Loot(this);
        }

        public override string ToString()
        {
            return
                $"{nameof(Name)}: {Name}, {nameof(HitPoint)}: {HitPoint}";
        }
    }
}
