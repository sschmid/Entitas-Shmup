using Entitas;

public static class EntityIndexPoolsExtensions {

    public const string PlayerKey = "Player";

    public static void AddEntityIndices(this Pools pools) {
        var playerIndex = new PrimaryEntityIndex<string>(
            pools.core.GetGroup(CoreMatcher.Player),
            (entity, component) => {
                var playerComponent = (PlayerComponent)component;
                return playerComponent != null
                    ? playerComponent.id
                    : entity.player.id;
            }
        );

        pools.core.AddEntityIndex(PlayerKey, playerIndex);
    }

    public static Entity GetEntityWithPlayerId(this Pool pool, string id) {
        var index = (PrimaryEntityIndex<string>)pool.GetEntityIndex(PlayerKey);
        return index.GetEntity(id);
    }
}
