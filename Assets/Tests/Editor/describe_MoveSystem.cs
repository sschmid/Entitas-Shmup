using Entitas;
using NSpec;
using UnityEngine;

class describe_MoveSystem : nspec {

    void when_executing() {

        it["adds move to position in multiple pools"] = () => {

            // given
            var corePool = TestHelper.CreateCorePool();
            var bulletsPool = TestHelper.CreateBulletPool();

            var entity1 = corePool.CreateEntity()
                .AddPosition(Vector3.one)
                .AddVelocity(Vector3.one);

            var entity2 = bulletsPool.CreateEntity()
                .AddPosition(Vector3.one)
                .AddVelocity(Vector3.one);

            var system = new VelocitySystem(corePool, bulletsPool);

            // when
            system.Execute();

            // then
            entity1.position.value.should_be(new Vector3(2, 2, 2));
            entity2.position.value.should_be(new Vector3(2, 2, 2));
        };
    }
}

