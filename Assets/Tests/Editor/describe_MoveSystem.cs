using Entitas;
using NSpec;
using UnityEngine;

class describe_MoveSystem : nspec {

    void when_executing() {

        it["adds move to position in multiple pools"] = () => {

            // given
            var corePool = TestHelper.CreateCorePool();
            var entity = corePool.CreateEntity()
                .AddPosition(Vector3.one)
                .AddVelocity(Vector3.one);

            var system = new VelocitySystem(corePool);

            // when
            system.Execute();

            // then
            entity.position.value.should_be(new Vector3(2, 2, 2));
        };
    }
}

