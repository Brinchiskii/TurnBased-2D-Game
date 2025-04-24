using TurnBased2DGame.Interfaces;

namespace TurnBased2DGame;

public class Wizard : Creature
{
    public Wizard()
    {
        
    }

    public Wizard(int x, int y, string name, int hitPoint, ICreatureNotifier? notifier = null) : base(x, y, name, hitPoint, notifier)
    {
        
    }
    
    protected override void ExecuteTurn(Creature target)
    {
        Attack(target);
    }
}