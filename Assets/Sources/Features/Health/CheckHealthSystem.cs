using System.Collections.Generic;
using Entitas;

public sealed class CheckHealthSystem : ISetPools, IEntityCollectorSystem {

    public EntityCollector entityCollector { get { return _groupObserver; } }

    EntityCollector _groupObserver;

    public void SetPools(Pools pools) {
        _groupObserver = new [] { pools .core, pools.bullets }
            .CreateEntityCollector(CoreMatcher.Health);
    }


    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            if(e.health.value <= 0) {
                e.flagDestroy = true;
            }
        }
    }
}
