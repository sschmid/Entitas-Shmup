using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewSystem : IReactiveSystem {

    public TriggerOnEvent trigger { get { return CoreMatcher.Resource.OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var gameObject = Object.Instantiate(Resources.Load<GameObject>(e.resource.name));
            e.AddView(gameObject);
        }
    }
}