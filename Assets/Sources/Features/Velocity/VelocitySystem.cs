using Entitas;

public class VelocitySystem : IExecuteSystem, ISetPool {

    Group _movables;

    public void SetPool(Pool pool) {
        _movables = pool.GetGroup(Matcher.AllOf(CoreMatcher.Velocity, CoreMatcher.Position));
    }

    public void Execute() {
        foreach (var e in _movables.GetEntities()) {
            var pos = e.position.value;
            e.ReplacePosition(pos + e.velocity.value);
        }
    }
}

