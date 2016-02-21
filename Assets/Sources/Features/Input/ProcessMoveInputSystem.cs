using Entitas;
using System.Collections.Generic;

public class ProcessMoveInputSystem : IReactiveSystem, ISetPool {

    public TriggerOnEvent trigger { get { return InputMatcher.MoveInput.OnEntityAdded();}}

    // TODO
    readonly Group _todoGroup;

    Pool _inputPool;

    public void SetPool(Pool pool) {
        _inputPool = pool;
    }

    public ProcessMoveInputSystem(Pool corePool) {
        _todoGroup = corePool.GetGroup(CoreMatcher.Position);
    }

    public void Execute(List<Entity> entities) {
        var input = entities.SingleEntity();
        
        foreach (var e in _todoGroup.GetEntities()) {
            e.ReplacePosition(e.position.value + input.moveInput.direction);
        }

        _inputPool.DestroyEntity(input);
    }
}
