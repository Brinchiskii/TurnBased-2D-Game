using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBased_2D_Game
{
    class Creature
    {
        private readonly List<AttackItem> _attackItems;
        private readonly List<DefenceItem> _defenceItems;
        
        public string Name { get; set; }
        public int HitPoint { get; set; }

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

            if (HitPoint < 0)
            {
                Console.WriteLine($"{Name} is defeated!");
            }
        }

        public void Loot(WorldObject worldObject)
        {
            if (!worldObject.Lootable)
            {
                return;
            }

            switch (worldObject)
            {
                case AttackItem attackItem:
                    _attackItems.Add(attackItem);
                    break;
                case DefenceItem defenceItem:
                    _defenceItems.Add(defenceItem);
                    break;
            }
        }
    }
}
