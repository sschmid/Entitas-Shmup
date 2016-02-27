using Entitas;
using NUnit.Framework;
using UnityEngine;
using UnityEditor.VersionControl;

public class AddViewFromObjectPoolSystemTests {

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
    }
}
