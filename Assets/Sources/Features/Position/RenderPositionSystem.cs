using System.Collections.Generic;
using Entitas;

public class RenderPositionSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.View, CoreMatcher.Position).OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            e.view.controller.position = e.position.value;
        }
    }
}