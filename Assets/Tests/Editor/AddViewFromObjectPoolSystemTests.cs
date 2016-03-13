using Entitas;
using NUnit.Framework;
using UnityEngine;

public class AddViewFromObjectPoolSystemTests {

    [Test]
    public void AddsView() {

        // given
        var pool = new Pool(BulletsComponentIds.TotalComponents);
        var system = (IExecuteSystem)pool.CreateSystem<AddViewFromObjectPoolSystem>();
        var gameObject = new GameObject();
        var controller = gameObject.AddComponent<ViewController>();

        gameObject.SetActive(false);
        var objectPool = new ObjectPool<GameObject>(() => gameObject);
        var entity = pool.CreateEntity().AddGameObjectObjectPool(objectPool);

        // when 
        system.Execute();

        // then
        Assert.AreSame(controller, entity.view.controller);
        Assert.IsTrue(gameObject.activeSelf);

        var link = entity.view.controller.entityLink;
        Assert.AreSame(entity, link.entity);
        Assert.AreSame(pool, link.pool);

        #if !ENTITAS_FAST_AND_UNSAFE
        Assert.AreEqual(3, entity.owners.Count); // Pool, GroupObserver, EntityLink
        Assert.IsTrue(entity.owners.Contains(link));
        #endif
    }

    [Test]
    public void SetsEntityLinkToPooledEntity() {

        // given
        var pool = new Pool(BulletsComponentIds.TotalComponents);
        var system = (IExecuteSystem)pool.CreateSystem<AddViewFromObjectPoolSystem>();

        var objectPool = new ObjectPool<GameObject>(() => null);
        var gameObject = new GameObject();
        var controller = gameObject.AddComponent<ViewController>();

        var entity = pool.CreateEntity().AddGameObjectObjectPool(objectPool);
        var link = controller.Link(entity, new Pool(1));
        controller.Unlink();

        objectPool.Push(gameObject);
        gameObject.SetActive(false);

        // when 
        system.Execute();

        // then
        Assert.AreSame(controller, entity.view.controller);

        var links = gameObject.GetComponents<EntityLink>();
        Assert.AreEqual(1, links.Length);

        var newLink = entity.view.controller.entityLink;
        Assert.AreSame(link, newLink);
        Assert.AreSame(entity, link.entity);
        Assert.AreSame(pool, link.pool);

        #if !ENTITAS_FAST_AND_UNSAFE
        Assert.AreEqual(3, entity.owners.Count); // Pool, GroupObserver, EntityLink
        Assert.IsTrue(entity.owners.Contains(newLink));
        #endif
    }
}