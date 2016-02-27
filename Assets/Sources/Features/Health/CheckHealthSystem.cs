using System.Collections.Generic;
using Entitas;

public class CheckHealthSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return CoreMatcher.Health.OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            if (e.health.value <= 0) {
                e.flagDestroy = true;
            }
        }
    }
}