using Entitas;
using System.Collections.Generic;

public sealed class ProcessMoveInputSystem : ISetPools, IReactiveSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.MoveInput.OnEntityAdded(); } }


    Pools _pools;

    public void SetPools(Pools pools) {
        _pools = pools;
    }

    public void Execute(List<Entity> entities) {
        var input = entities[entities.Count - 1];
        var ownerId = input.inputOwner.playerId;

        var e = _pools.core.GetEntityWithPlayerId(ownerId);

        // TODO Speed Shoud be configurable
        e.ReplaceVelocity(input.moveInput.direction.normalized * 0.3f);
    }
}
