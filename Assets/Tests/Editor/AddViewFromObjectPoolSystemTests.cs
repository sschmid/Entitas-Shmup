using Entitas;
using NUnit.Framework;
using UnityEngine;

public class AddViewFromObjectPoolSystemTests {


    [SetUp]
    public void Before() {
        
    }

    [Test]
    public void AddsView() {

        // given
        var pool = new Pool(BulletsComponentIds.TotalComponents);
        var system = (IExecuteSystem)pool.CreateSystem<AddViewFromObjectPoolSystem>();
        var gameObject = new GameObject();
        gameObject.SetActive(false);
        var objectPool = new ObjectPool<GameObject>(() => gameObject);
        var entity = pool.CreateEntity().AddGameObjectObjectPool(objectPool);

        // when 
        system.Execute();

        // then
        Assert.AreSame(gameObject, entity.view.gameObject);
        Assert.IsTrue(gameObject.activeSelf);

        var link = entity.view.gameObject.GetComponent<EntityLink>();
        Assert.AreSame(entity, link.entity);
        Assert.AreSame(pool, link.pool);

        Assert.AreEqual(3, entity.owners.Count); // Pool, GroupObserver, EntityLink
        Assert.IsTrue(entity.owners.Contains(link));
    }

    [Test]
    public void SetsEntityLinkToPooledEntity() {

        // given
        var pool = new Pool(BulletsComponentIds.TotalComponents);
        var system = (IExecuteSystem)pool.CreateSystem<AddViewFromObjectPoolSystem>();

        var objectPool = new ObjectPool<GameObject>(() => null);
        var gameObject = new GameObject();
        var link = gameObject.AddComponent<EntityLink>();
        objectPool.Push(gameObject);
        gameObject.SetActive(false);

        var entity = pool.CreateEntity().AddGameObjectObjectPool(objectPool);
        link.Link(pool.CreateEntity(), new Pool(1));
        link.Unlink();

        // when 
        system.Execute();

        // then
        Assert.AreSame(gameObject, entity.view.gameObject);

        var links = entity.view.gameObject.GetComponents<EntityLink>();
        Assert.AreEqual(1, links.Length);

        var newLink = entity.view.gameObject.GetComponent<EntityLink>();
        Assert.AreSame(link, newLink);
        Assert.AreSame(entity, link.entity);
        Assert.AreSame(pool, link.pool);

        Assert.AreEqual(3, entity.owners.Count); // Pool, GroupObserver, EntityLink
        Assert.IsTrue(entity.owners.Contains(newLink));
    }
}
