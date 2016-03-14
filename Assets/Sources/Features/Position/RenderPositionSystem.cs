using System.Collections.Generic;
using Entitas;

public class RenderPositionSystem : IGroupObserverSystem {

    public GroupObserver groupObserver { get { return _groupObserver; } }

    readonly GroupObserver _groupObserver;

    public RenderPositionSystem(params Pool[] pools) {
        _groupObserver = pools.CreateGroupObserver(Matcher.AllOf(CoreMatcher.View, CoreMatcher.Position));
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            e.view.controller.position = e.position.value;
        }
    }
}