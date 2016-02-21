using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DestroyViewSystem : IReactiveSystem, IEnsureComponents {
    public TriggerOnEvent trigger { get { return CoreMatcher.Destroy.OnEntityAdded(); } }

    public IMatcher ensureComponents { get { return CoreMatcher.View; } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            Object.Destroy(e.view.gameObject);
        }
    }
}