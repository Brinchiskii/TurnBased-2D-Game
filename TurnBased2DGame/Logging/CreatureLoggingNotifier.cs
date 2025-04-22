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
}