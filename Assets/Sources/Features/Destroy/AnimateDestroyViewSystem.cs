using System.Collections.Generic;
using Entitas;

public class AnimateDestroyViewSystem : IGroupObserverSystem {

    public GroupObserver groupObserver { get { return _groupObserver; } }

    readonly GroupObserver _groupObserver;

    public AnimateDestroyViewSystem(params Pool[] pools) {
        _groupObserver = pools.CreateGroupObserver(Matcher.AllOf(CoreMatcher.View, CoreMatcher.Destroy));
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            e.view.controller.Despawn();
        }
    }
}