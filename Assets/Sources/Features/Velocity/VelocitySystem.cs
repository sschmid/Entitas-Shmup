using Entitas;

public sealed class VelocitySystem : ISetPools, IExecuteSystem {

    Group[] _movableGroups;

    public void SetPools(Pools pools) {
        var matcher = Matcher.AllOf(CoreMatcher.Velocity, CoreMatcher.Position);
        _movableGroups = new [] {
            pools.core.GetGroup(matcher),
            pools.bullets.GetGroup(matcher)
        };
    }

    public void Execute() {
        foreach(var group in _movableGroups) {
            foreach(var e in group.GetEntities()) {
                var pos = e.position.value;
                e.ReplacePosition(pos + e.velocity.value);
            }
        }
    }
}
