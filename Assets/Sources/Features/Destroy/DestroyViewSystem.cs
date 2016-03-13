using System.Collections.Generic;
using Entitas;

public class DestroyViewSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.View, CoreMatcher.Destroy).OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            e.view.controller.Despawn();
        }
    }
}