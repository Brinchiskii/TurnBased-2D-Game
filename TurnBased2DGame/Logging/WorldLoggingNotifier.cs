using TurnBased2DGame.Interfaces;

namespace TurnBased2DGame;

public class WorldLoggingNotifier : IWorldNotifier
{
    public void OnWorldAddCreature(Creature creature)
    {
        Logger.Information($"Creature added({creature.Name}) to world");
    }

    public void OnWorldAddWorldObject(WorldObject worldObject)
    {
        Logger.Information($"WorldObject added({worldObject.Name}) to world");
    }

    public void OnWorldAddWorldObjectFailed(WorldObject worldObject, string errorMessage)
    {
        Logger.Warning($"WorldObject added({worldObject.Name}) failed: {errorMessage}");
    }
}