//using Entitas;
//using NUnit.Framework;
//using UnityEngine;

//public class RenderPositionSystemsTests {

//    [Test]
//    public void UpdatesView()
//    {
//        // given
//        var pool = TestHelper.CreateCorePool();
//        var gameObject = new GameObject();
//        var controller = gameObject.AddComponent<ViewController>();
//        var entity = pool.CreateEntity()
//            .AddPosition(Vector3.one)
//            .AddView(controller);

//        var system = new ReactiveSystem(new RenderPositionSystem(pool));

//        // when 
//        var newPos = new Vector3(2, 3, 4);
//        entity.ReplacePosition(newPos);
//        system.Execute();

//        // then
//        Assert.AreEqual(newPos, gameObject.transform.position);
//        Assert.AreEqual(newPos, controller.position);
//    }
//}
