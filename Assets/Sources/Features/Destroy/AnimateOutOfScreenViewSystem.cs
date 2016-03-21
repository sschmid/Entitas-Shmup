using System.Collections.Generic;
using Entitas;

public class AnimateOutOfScreenViewSystem : IGroupObserverSystem {

    public GroupObserver groupObserver { get { return _groupObserver; } }

    readonly GroupObserver _groupObserver;

    public AnimateOutOfScreenViewSystem(params Pool[] pools) {
        _groupObserver = pools.CreateGroupObserver(Matcher.AllOf(CoreMatcher.View, CoreMatcher.OutOfScreen));
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            e.view.controller.OutOfScreen();
        }
    }
}