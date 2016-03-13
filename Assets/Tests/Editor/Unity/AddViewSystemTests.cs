using Entitas;
using NUnit.Framework;
using UnityEngine;

public class AddViewSystemTests {

    [Test]
    public void AddsView()
    {
        // given
        var pool = TestHelper.CreateCorePool();
        var system = (IExecuteSystem)pool.CreateSystem<AddViewSystem>();

        var resourceName = Res.Spaceship;
        var entity = pool.CreateEntity().AddResource(resourceName);

        // when 
        system.Execute();

        // then
        Assert.IsTrue(entity.hasView);
        Assert.IsNotNull(entity.view.controller);

        var gameObject = Object.FindObjectOfType<GameObject>();
        Assert.AreEqual(resourceName + "(Clone)", gameObject.name);

        var link = gameObject.GetEntityLink();
        Assert.AreSame(entity, link.entity);
        Assert.AreSame(pool, link.pool);
    }
}
