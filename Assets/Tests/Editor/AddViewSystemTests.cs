using Entitas;
using NUnit.Framework;

public class AddViewSystemTests {

    [Test]
    public void AddsView()
    {
        // given
        var pool = new Pool(CoreComponentIds.TotalComponents);
        var system = (IExecuteSystem)pool.CreateSystem<AddViewSystem>();
        var resourceName = Res.Spaceship;
        var entity = pool.CreateEntity().AddResource(resourceName);

        // when 
        system.Execute();

        // then
        Assert.IsTrue(entity.hasView);
        Assert.IsNotNull(entity.view.gameObject);
        Assert.AreEqual(resourceName + "(Clone)", entity.view.gameObject.name);

        var link = entity.view.gameObject.GetComponent<EntityLink>();
        Assert.AreSame(entity, link.entity);
        Assert.AreSame(pool, link.pool);
    }
}
