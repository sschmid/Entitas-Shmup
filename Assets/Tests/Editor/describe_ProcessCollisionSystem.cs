using NSpec;
using UnityEngine;
using Entitas;

class describe_ProcessCollisionSystem : nspec {

    void when_executing() {


        it["destroys both entities in CollisionComponent"] = () => {
            
            // given
            var corePool = new Pool(CoreComponentIds.TotalComponents);
            var inputPool = new Pool(InputComponentIds.TotalComponents);
            var bulletPool = new Pool(BulletsComponentIds.TotalComponents);
            var system = (IExecuteSystem)inputPool.CreateSystem<ProcessCollisionSystem>();

            var bullet = bulletPool.CreateEntity();
            var enemy = corePool.CreateEntity();

            var collision = inputPool.CreateEntity()
            .AddCollision(bullet, enemy);

            // when
            system.Execute();

            // then
            bullet.flagDestroy.should_be_true();
            enemy.flagDestroy.should_be_true();

            inputPool.GetEntities(InputMatcher.Collision).Length.should_be(0);
        };
    }
}

