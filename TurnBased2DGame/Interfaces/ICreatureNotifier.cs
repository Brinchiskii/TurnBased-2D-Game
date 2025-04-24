namespace TurnBased2DGame.Interfaces;

/// <summary>
/// Defines a contract for handling creature-related events.
/// </summary>
public interface ICreatureNotifier
{
    /// <summary>
    /// Called when a creature receives damage.
    /// </summary>
    /// <param name="creature">The creature that was hit</param>
    /// <param name="originalHit">The incoming damage</param>
    /// <param name="finalDamage">The damage after defence reduction</param>
    void OnCreatureHit(Creature creature, int originalHit, int finalDamage);
    
    /// <summary>
    /// Called when a creature is defeated.
    /// </summary>
    /// <param name="creature">The defeated creature.</param>
    void OnCreatureDefeated(Creature creature);
    
    /// <summary>
    /// Called when a creature tries to loot and non lootable item
    /// </summary>
    /// <param name="creature">The creature that loots the item</param>
    /// <param name="worldObject">The item that is tried looted</param>
    void OnCreatureLootingFailed(Creature creature, WorldObject worldObject);
    
    /// <summary>
    /// Called when a creature loots an item
    /// </summary>
    /// <param name="creature">The creature that loots the item</param>
    /// <param name="worldObject">The item that is looted</param>
    void OnCreatureLooting(Creature creature, WorldObject worldObject);
    
    /// <summary>
    /// Called when creature preparing for its turn
    /// </summary>
    /// <param name="creature">The creature that prepares</param>
    void OnCreaturePreparingTurn(Creature creature);
    
    /// <summary>
    /// Called when creature ends its turn
    /// </summary>
    /// <param name="creature">The creature that ends its turn</param>
    void OnCreatureEndingTurn(Creature creature);
    
    void OnCreatureMoved(Creature creature);
    
    void OnCreatureAttack(Creature creature, Creature target, int damage);
}