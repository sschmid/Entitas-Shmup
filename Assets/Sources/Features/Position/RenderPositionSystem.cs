using System.Collections.Generic;
using Entitas;

public sealed class RenderPositionSystem : ISetPools, IGroupObserverSystem {

    public GroupObserver groupObserver { get { return _groupObserver; } }

    GroupObserver _groupObserver;

    public void SetPools(Pools pools) {
        _groupObserver = new [] { pools.core, pools.bullets }
            .CreateGroupObserver(Matcher.AllOf(CoreMatcher.View, CoreMatcher.Position));
    }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            e.view.controller.position = e.position.value;
        }
    }
}
