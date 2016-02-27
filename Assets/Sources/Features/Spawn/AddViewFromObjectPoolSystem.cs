using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewFromObjectPoolSystem : IReactiveSystem, ISetPool {

    public TriggerOnEvent trigger { get { return BulletsMatcher.GameObjectObjectPool.OnEntityAdded(); } }

    Pool _pool;
    Transform _container;

    public void SetPool(Pool pool) {
        _pool = pool;
        _container = new GameObject(pool.metaData.poolName + " Views").transform;
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var gameObject = e.gameObjectObjectPool.pool.Get();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_container, false);

            var entityLink = gameObject.GetComponent<EntityLink>();
            if (entityLink == null) {
                entityLink = gameObject.AddComponent<EntityLink>();
            }
            entityLink.Link(e, _pool);

            e.AddView(gameObject);
        }
    }
}