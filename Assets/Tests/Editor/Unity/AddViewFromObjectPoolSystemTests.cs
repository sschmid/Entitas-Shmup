using Entitas;
using NUnit.Framework;
using UnityEngine;

public class AddViewFromObjectPoolSystemTests {

    [Test]
    public void AddsView() {

        // given
        var pool = TestHelper.CreateBulletsPool();
        var system = (IExecuteSystem)pool.CreateSystem(new AddViewFromObjectPoolSystem());

        var gameObject = new GameObject();
        var controller = gameObject.AddComponent<ViewController>();

        var objectPool = new ObjectPool<GameObject>(() => gameObject);
        gameObject.SetActive(false);

        var entity = pool.CreateEntity().AddViewObjectPool(objectPool);

        // when 
        system.Execute();

        // then
        Assert.AreSame(controller, entity.view.controller);
        Assert.IsTrue(gameObject.activeSelf);

        var link = gameObject.GetEntityLink();
        Assert.AreSame(entity, link.entity);
        Assert.AreSame(pool, link.pool);
    }
}