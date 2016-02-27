using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AddViewFromObjectPoolSystem : IReactiveSystem, ISetPool {

    public TriggerOnEvent trigger { get { return BulletsMatcher.GameObjectObjectPool.OnEntityAdded(); } }

    Transform _container;

    public void SetPool(Pool pool) {
        _container = new GameObject(pool.metaData.poolName + " Views").transform;
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var gameObject = e.gameObjectObjectPool.pool.Get();
            gameObject.SetActive(true);
            gameObject.transform.SetParent(_container, false);
            e.AddView(gameObject);
        }
    }
}