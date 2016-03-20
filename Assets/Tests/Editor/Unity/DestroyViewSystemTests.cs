﻿using Entitas;
using NUnit.Framework;
using UnityEngine;

public class DestroyViewSystemTests {

    [Test]
    public void DespawnsView() {
        // given
        var corePool = TestHelper.CreateBulletsPool();
        var system = new ReactiveSystem(new DestroyViewSystem(corePool));

        var gameObject = new GameObject();
        var controller = gameObject.AddComponent<DespawnTestViewController>();
        corePool.CreateEntity().AddView(controller).FlagDestroy(true);

        // when 
        system.Execute();

        // then
        Assert.IsTrue(controller.despawnCalled);
    }

    [Test]
    public void DeactivatesViewWhenOutOfScreen() {
        // given
        var corePool = TestHelper.CreateBulletsPool();
        var system = new ReactiveSystem(new DestroyViewSystem(corePool));

        var gameObject = new GameObject();
        var controller = gameObject.AddComponent<DespawnTestViewController>();
        corePool.CreateEntity().AddView(controller).FlagDestroy(true).IsOutOfScreen(true);

        // when 
        system.Execute();

        // then
        Assert.IsFalse(controller.despawnCalled);
        Assert.IsTrue(controller.deactiveCalled);
    }
}

class DespawnTestViewController : MonoBehaviour, IViewController {

    public bool despawnCalled = false;
    public bool deactiveCalled = false;

    public Vector3 position { get { throw new System.NotImplementedException(); } set { throw new System.NotImplementedException(); } }

    public virtual void Despawn() {
        despawnCalled = true;
    }

    public void Deactivate() {
        deactiveCalled = true;
    }
}
