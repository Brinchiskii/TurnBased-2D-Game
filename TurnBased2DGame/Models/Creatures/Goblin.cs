using TurnBased2DGame.Interfaces;

namespace TurnBased2DGame;

public class Goblin : Creature
{
    public Goblin()
    {
        
    }
    
    public Goblin(int x, int y, string name, int hitPoint, ICreatureNotifier? notifier) : base(x, y, name, hitPoint, notifier)
    {
        
    }
    
    protected override void ExecuteTurn(Creature target)
    {
        Attack(target);
    }
}