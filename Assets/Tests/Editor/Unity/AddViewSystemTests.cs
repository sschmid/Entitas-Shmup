using Entitas;
using NUnit.Framework;
using UnityEngine;

public class AddViewSystemTests {

    [Test]
    public void AddsView()
    {
        // given
        var pool = TestHelper.CreateCorePool();
        var system = (IExecuteSystem)pool.CreateSystem(new AddViewSystem());

        var resourceName = Res.Spaceship;
        var entity = pool.CreateEntity().AddAsset(resourceName);

        // when 
        system.Execute();

        // then
        Assert.IsTrue(entity.hasView);
        Assert.IsNotNull(entity.view.controller);

        var link = Object.FindObjectOfType<ViewController>().gameObject.GetEntityLink();
        Assert.AreSame(entity, link.entity);
        Assert.AreSame(pool, link.pool);
    }
}
