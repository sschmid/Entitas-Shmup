using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewFromObjectPoolSystem : IReactiveSystem, ISetPool, IEnsureComponents {

    public TriggerOnEvent trigger { get { return BulletsMatcher.ViewObjectPool.OnEntityAdded(); } }

    public IMatcher ensureComponents { get { return BulletsMatcher.ViewObjectPool; } }

    Pool _pool;
    Transform _container;

    public void SetPool(Pool pool) {
        _pool = pool;
        _container = new GameObject(pool.metaData.poolName + " Views").transform;
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var gameObject = e.viewObjectPool.pool.Get();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_container, false);
            gameObject.Link(e, _pool);
            e.AddView(gameObject.GetComponent<ViewController>());
        }
    }
}