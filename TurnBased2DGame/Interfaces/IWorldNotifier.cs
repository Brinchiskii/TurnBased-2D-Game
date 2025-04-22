namespace TurnBased2DGame.Interfaces;

public interface IWorldNotifier
{
    void OnWorldAddCreature(Creature creature);
    void OnWorldAddWorldObject(WorldObject worldObject);
}