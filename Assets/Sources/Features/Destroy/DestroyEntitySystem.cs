using System.Collections.Generic;
using Entitas;

public sealed class DestroyEntitySystem : ISetPools, IGroupObserverSystem {

    public GroupObserver groupObserver { get { return _groupObserver; } }

    Pool[] _pools;
    GroupObserver _groupObserver;

    public void SetPools(Pools pools) {
        _pools = new [] { pools.core, pools.bullets };
        _groupObserver = _pools.CreateGroupObserver(Matcher.AnyOf(CoreMatcher.Destroy, CoreMatcher.OutOfScreen));
    }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            foreach(var pool in _pools) {
                if(pool.HasEntity(e)) {
                    pool.DestroyEntity(e);
                    break;
                }
            }
        }
    }
}
