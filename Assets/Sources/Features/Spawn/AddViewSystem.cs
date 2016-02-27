using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewSystem : IReactiveSystem, ISetPool {

    public TriggerOnEvent trigger { get { return CoreMatcher.Resource.OnEntityAdded(); } }

    Pool _pool;
    Transform _container;

    public void SetPool(Pool pool) {
        _pool = pool;
        _container = new GameObject(pool.metaData.poolName + " Views").transform;
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var gameObject = Object.Instantiate(Resources.Load<GameObject>(e.resource.name));
            gameObject.transform.SetParent(_container, false);
            gameObject.AddComponent<EntityLink>().Link(e, _pool);
            e.AddView(gameObject);
        }
    }
}