using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased2DGame
{
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

        public int Hit()
        {
            if (_attackItems.Count == 0)
            {
                return 0;
            }

            int totalHit = _attackItems.Sum(item => item.Hit);
            return totalHit;
        }

        public void ReceiveHit(int hit)
        {
            int totalDefence = _defenceItems.Sum(item => item.ReduceHitPoint);
            int finalDamage = Math.Max(0, hit - totalDefence);
            
            HitPoint -= finalDamage;

            Logger.Log($"{Name} received hit, {hit} damage, (after {totalDefence} defence). Remaining HP: {HitPoint}");
            
            if (HitPoint < 0)
            {
                Logger.Log($"{Name} is defeated!");
            }
        }

        public void Loot(WorldObject worldObject)
        {
            if (!worldObject.Lootable)
            {
                Logger.Log($"{Name} tried to loot '{worldObject.Name}', but it is not lootable.");
                return;
            }

            switch (worldObject)
            {
                case AttackItem attackItem:
                    _attackItems.Add(attackItem);
                    Logger.Log($"{Name} looted AttackItem '{attackItem.Name}' (Hit: {attackItem.Hit})");
                    break;
                case DefenceItem defenceItem:
                    _defenceItems.Add(defenceItem);
                    Logger.Log($"{Name} looted DefenceItem '{defenceItem.Name}' (Defense: {defenceItem.ReduceHitPoint})");
                    break;
                
                default:
                    Logger.Log($"{Name} looted unknown object '{worldObject.Name}'");
                    break;
            }
        }

        public void AddDefenceItem(DefenceItem defenceItem)
        {
            _defenceItems.Add(defenceItem);
            Logger.Log($"{Name} added DefenceItem '{defenceItem.Name}'");
        }

        public override string ToString()
        {
            return
                $"{nameof(Name)}: {Name}, {nameof(HitPoint)}: {HitPoint}";
        }
    }
}
