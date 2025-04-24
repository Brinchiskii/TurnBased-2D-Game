using TurnBased2DGame.Interfaces;

namespace TurnBased2DGame;

public class CreatureLoggingNotifier : ICreatureNotifier
{
    public void OnCreatureHit(Creature creature, int originalHit, int finalDamage)
    {
        Logger.Information($"{creature.Name} received hit: {originalHit} damage (after {originalHit - finalDamage} defense). Remaining HP: {creature.HitPoint}");    }

    public void OnCreatureDefeated(Creature creature)
    {
        Logger.Information($"{creature.Name} has been defeated!");    
    }

    public void OnCreatureLootingFailed(Creature creature, WorldObject worldObject)
    {
        Logger.Warning($"{creature.Name} tried to loot '{worldObject.Name}', but it is not lootable.");
    }

    public void OnCreatureLooting(Creature creature, WorldObject worldObject)
    {
        Logger.Information($"{creature.Name} looted {worldObject.GetType()} '{worldObject.Name}'");
    }

    public void OnCreaturePreparingTurn(Creature creature)
    {
        Logger.Information($"{creature.Name} is preparing turn...");
    }

    public void OnCreatureEndingTurn(Creature creature)
    {
        Logger.Information($"{creature.Name} ends turn...");
    }

    public void OnCreatureMoved(Creature creature)
    {
        Logger.Information($"{creature.Name} moves to position ({creature.X}, {creature.Y}).");
    }

    public void OnCreatureAttack(Creature creature, Creature target, int damage)
    {
        Logger.Information($"{creature.Name} attacked {target.Name} for {damage} damage.");
    }
}