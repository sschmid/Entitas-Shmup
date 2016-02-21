using System.Collections.Generic;
using Entitas;

public class RenderPositionSystem : IReactiveSystem, IEnsureComponents {
    public TriggerOnEvent trigger { get { return CoreMatcher.Position.OnEntityAdded(); } }

    public IMatcher ensureComponents { get { return CoreMatcher.View; } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            e.view.gameObject.transform.position = e.position.value;
        }
    }
}