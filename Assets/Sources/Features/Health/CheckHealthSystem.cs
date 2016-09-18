using System.Collections.Generic;
using Entitas;

public sealed class CheckHealthSystem : ISetPools, IGroupObserverSystem {

    public GroupObserver groupObserver { get { return _groupObserver; } }

    GroupObserver _groupObserver;

    public void SetPools(Pools pools) {
        _groupObserver = new [] { pools .core, pools.bullets }
            .CreateGroupObserver(CoreMatcher.Health);
    }


    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            if(e.health.value <= 0) {
                e.flagDestroy = true;
            }
        }
    }
}
