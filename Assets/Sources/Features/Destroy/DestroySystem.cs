using System.Collections.Generic;
using Entitas;

public class DestroySystem : IGroupObserverSystem {

    public GroupObserver groupObserver { get { return _groupObserver; } }

    readonly Pool[] _pools;
    readonly GroupObserver _groupObserver;

    public DestroySystem(params Pool[] pools) {
        _pools = pools;
        _groupObserver = pools.CreateGroupObserver(CoreMatcher.Destroy);
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            foreach (var pool in _pools) {
                if (pool.HasEntity(e)) {
                    pool.DestroyEntity(e);
                }
            }
        }
    }
}