using System.Collections.Generic;
using Entitas;

public sealed class AnimateOutOfScreenViewSystem : ISetPools, IEntityCollectorSystem {

    public EntityCollector entityCollector { get { return _groupObserver; } }

    EntityCollector _groupObserver;

    public void SetPools(Pools pools) {
        _groupObserver = new [] { pools.core, pools.bullets }
            .CreateEntityCollector(Matcher.AllOf(CoreMatcher.View, CoreMatcher.OutOfScreen));
    }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            var controller = e.view.controller;
            controller.Hide(false);
        }
    }
}
