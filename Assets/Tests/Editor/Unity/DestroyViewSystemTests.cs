using Entitas;
using NUnit.Framework;
using UnityEngine;

public class DestroyViewSystemTests {

    [Test]
    public void DestroyView() {
        // given
        var pool = TestHelper.CreateBulletPool();
        var system = (IExecuteSystem)pool.CreateSystem<DestroyViewSystem>();
        var gameObject = new GameObject();
        var controller = gameObject.AddComponent<DespawnTestViewController>();
        pool.CreateEntity().AddView(controller).FlagDestroy(true);

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
