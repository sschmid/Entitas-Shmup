using System.Collections.Generic;
using Entitas;

public sealed class DestroyEntitySystem : ISetPools, IEntityCollectorSystem {

    public EntityCollector entityCollector { get { return _groupObserver; } }

    Pool[] _pools;
    EntityCollector _groupObserver;

    public void SetPools(Pools pools) {
        _pools = new [] { pools.core, pools.bullets };
        _groupObserver = _pools.CreateEntityCollector(Matcher.AnyOf(CoreMatcher.Destroy, CoreMatcher.OutOfScreen));
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
