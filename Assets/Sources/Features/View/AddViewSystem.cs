using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ISetPool, IInitializeSystem, IReactiveSystem {

    public TriggerOnEvent trigger { get { return CoreMatcher.Asset.OnEntityAdded(); } }

    Pool _pool;
    Transform _container;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _container = new GameObject(_pool.metaData.poolName + " Views").transform;
    }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            var gameObject = Assets.Instantiate<GameObject>(e.asset.name);
            gameObject.transform.SetParent(_container, false);
            gameObject.Link(e, _pool);
            e.AddView(gameObject.GetComponent<IViewController>());
        }
    }
}
