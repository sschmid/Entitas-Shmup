using Entitas;

public class VelocitySystem : IExecuteSystem {

    readonly Group[] _movableGroups;

    public VelocitySystem(params Pool[] pools) {
        _movableGroups = new Group[pools.Length];
        for (int i = 0; i < pools.Length; i++) {
            _movableGroups[i] = pools[i].GetGroup(Matcher.AllOf(CoreMatcher.Velocity, CoreMatcher.Position));
        }
    }

    public void Execute() {
        foreach (var group in _movableGroups) {
            foreach (var e in group.GetEntities()) {
                var pos = e.position.value;
                e.ReplacePosition(pos + e.velocity.value);
            }
        }
    }
}

