using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewFromObjectPoolSystem : ISetPool, IInitializeSystem, IReactiveSystem, IEnsureComponents {

    public TriggerOnEvent trigger { get { return BulletsMatcher.ViewObjectPool.OnEntityAdded(); } }

    public IMatcher ensureComponents { get { return BulletsMatcher.ViewObjectPool; } }

    Pool _pool;
    Transform _container;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _container = new GameObject(_pool.metaData.poolName + " Views (Pooled)").transform;
    }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            var gameObject = e.viewObjectPool.pool.Get();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_container, false);
            gameObject.Link(e, _pool);
            e.AddView(gameObject.GetComponent<IViewController>());
        }
    }
}
