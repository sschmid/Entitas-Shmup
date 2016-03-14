using Entitas;
using NUnit.Framework;
using UnityEngine;

public class DestroyViewSystemTests {

    [Test]
    public void DestroyView() {
        // given
        var corePool = TestHelper.CreateBulletsPool();
        var bulletsPool = TestHelper.CreateBulletsPool();
        var system = new ReactiveSystem(new DestroyViewSystem(corePool));

        var gameObject = new GameObject();
        var controller = gameObject.AddComponent<DespawnTestViewController>();
        corePool.CreateEntity().AddView(controller).FlagDestroy(true);

        // when 
        system.Execute();

        // then
        Assert.IsTrue(controller.despawnCalled);
    }
}

class DespawnTestViewController : MonoBehaviour, IViewController {

    public bool despawnCalled = false;

    public Vector3 position { get { throw new System.NotImplementedException(); } set { throw new System.NotImplementedException(); } }

    public virtual void Despawn() {
        despawnCalled = true;
    }
}
