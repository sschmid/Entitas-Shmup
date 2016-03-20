using System.Collections.Generic;
using Entitas;

public class DestroyViewSystem : IGroupObserverSystem {

    public GroupObserver groupObserver { get { return _groupObserver; } }

    readonly GroupObserver _groupObserver;

    public DestroyViewSystem(params Pool[] pools) {
        _groupObserver = pools.CreateGroupObserver(Matcher.AllOf(CoreMatcher.View, CoreMatcher.Destroy));
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            if (e.isOutOfScreen) {
                ((IPooledViewController)e.view.controller).Deactivate();
            } else {
                e.view.controller.Despawn();
            }
        }
    }
}