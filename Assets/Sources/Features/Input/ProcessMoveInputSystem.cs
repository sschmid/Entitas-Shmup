using Entitas;
using System.Collections.Generic;

public class ProcessMoveInputSystem : IReactiveSystem, ISetPool {

    public TriggerOnEvent trigger { get { return InputMatcher.MoveInput.OnEntityAdded();}}

    readonly Group _players;

    Pool _inputPool;

    public void SetPool(Pool pool) {
        _inputPool = pool;
    }

    public ProcessMoveInputSystem(Pool corePool) {
        _players = corePool.GetGroup(Matcher.AllOf(CoreMatcher.Player, CoreMatcher.Position));
    }

    public void Execute(List<Entity> entities) {
        var input = entities.SingleEntity();
        var ownerId = input.inputOwner.playerId;
        
        foreach (var e in _players.GetEntities()) {
            if (e.player.id == ownerId) {
                e.ReplaceVelocity(input.moveInput.direction);
            }
        }

        _inputPool.DestroyEntity(input);
    }
}
