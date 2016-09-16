//using Entitas;
//using NUnit.Framework;
//using UnityEngine;

//public class AnimateOutOfScreenViewSystemTests {

//    [Test]
//    public void DeactivatesViewWhenOutOfScreen() {
//        // given
//        var corePool = TestHelper.CreateBulletsPool();
//        var system = new ReactiveSystem(new AnimateOutOfScreenViewSystem(corePool));

//        var gameObject = new GameObject();
//        var controller = gameObject.AddComponent<OutOfScreenTestViewController>();
//        corePool.CreateEntity().AddView(controller).FlagDestroy(true).IsOutOfScreen(true);

//        // when 
//        system.Execute();

//        // then
//        Assert.IsTrue(controller.outOfScreenCalled);
//    }
//}

//class OutOfScreenTestViewController : MonoBehaviour, IViewController {

//    public bool outOfScreenCalled = false;

//    public Vector3 position { get { throw new System.NotImplementedException(); } set { throw new System.NotImplementedException(); } }

//    public void Hide() {
//        outOfScreenCalled = true;
//    }

//    public virtual void HideAnimated() {
//        throw new System.NotImplementedException();
//    }
//}
