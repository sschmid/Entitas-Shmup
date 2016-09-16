using Entitas;
using System.Collections.Generic;

public sealed class ProcessMoveInputSystem : ISetPools, IReactiveSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.MoveInput.OnEntityAdded(); } }

    public const float SPEED = 0.3f;

    Group _players;

    public void SetPools(Pools pools) {
        _players = pools.core.GetGroup(Matcher.AllOf(CoreMatcher.Player, CoreMatcher.Position));
    }

    public void Execute(List<Entity> entities) {
        var input = entities[entities.Count - 1];
        var ownerId = input.inputOwner.playerId;

        // TODO Use EntityIndex
        foreach(var e in _players.GetEntities()) {
            if(e.player.id == ownerId) {

                // TODO Player speed should be configurable
                e.ReplaceVelocity(input.moveInput.direction.normalized * SPEED);
            }
        }
    }
}
