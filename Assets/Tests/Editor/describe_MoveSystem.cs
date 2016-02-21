using Entitas;
using NSpec;
using UnityEngine;

class describe_MoveSystem : nspec {

    void when_executing() {

        it["adds move to position"] = () => {

            // given
            var pool = new Pool(CoreComponentIds.TotalComponents);
            var entity = pool.CreateEntity()
                .AddPosition(Vector3.one)
                .AddVelocity(Vector3.one);

            var system = (IExecuteSystem)pool.CreateSystem<VelocitySystem>();

            // when
            system.Execute();

            // then
            entity.position.value.should_be(new Vector3(2, 2, 2));
        };
    }
}

