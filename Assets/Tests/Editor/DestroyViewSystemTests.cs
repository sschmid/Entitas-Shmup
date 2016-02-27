using Entitas;
using NUnit.Framework;
using UnityEngine;

public class DestroyViewSystemTests {

    [Test]
    public void DestroyView()
    {
        // given
        var pool = new Pool(BulletsComponentIds.TotalComponents);
        var system = (IExecuteSystem)pool.CreateSystem<DestroyViewSystem>();
        var gameObject = new GameObject();
        pool.CreateEntity().AddView(gameObject).FlagDestroy(true);

        // when 
        system.Execute();

        // then
        Assert.IsTrue(gameObject == null);
    }

    [Test]
    public void DestroyViewAndPutItInToObjectPool()
    {
        // given
        var pool = new Pool(BulletsComponentIds.TotalComponents);
        var system = (IExecuteSystem)pool.CreateSystem<DestroyViewSystem>();
        var gameObject = new GameObject();
        var objectPool = new ObjectPool<GameObject>(() => gameObject);
        var entity = pool.CreateEntity()
            .AddView(gameObject)
            .AddGameObjectObjectPool(objectPool)
            .FlagDestroy(true);

        // when 
        system.Execute();

        // then
        Assert.IsFalse(gameObject == null);
        Assert.IsFalse(gameObject.activeSelf);
        Assert.AreSame(gameObject, entity.gameObjectObjectPool.pool.Get());
    }
}

