using NSpec;
using Entitas;

class describe_ProcessCollisionSystem : nspec {

    void when_executing() {

        Pool corePool = null;
        Pool inputPool = null;
        Pool bulletPool = null;
        IExecuteSystem system = null;

        before = () => {
            corePool = new Pool(CoreComponentIds.TotalComponents);
            inputPool = new Pool(InputComponentIds.TotalComponents);
            bulletPool = new Pool(BulletsComponentIds.TotalComponents);
            system = (IExecuteSystem)inputPool.CreateSystem<ProcessCollisionSystem>();
        };

        it["destroys bullet and damages target in CollisionComponent"] = () => {
            
            // given
            var bullet = bulletPool.CreateEntity()
                .AddDamage(5);

            var enemy = corePool.CreateEntity()
                .AddHealth(10);

            var collision = inputPool.CreateEntity()
                .AddCollision(bullet, enemy);

            // when
            system.Execute();

            // then
            bullet.flagDestroy.should_be_true();
            enemy.flagDestroy.should_be_false();
            enemy.health.value.should_be(5);

            inputPool.GetEntities(InputMatcher.Collision).Length.should_be(0);
        };

        it["doesn't set target health less than 0"] = () => {
            
            // given
            var bullet = bulletPool.CreateEntity()
                .AddDamage(20);

            var enemy = corePool.CreateEntity()
                .AddHealth(10);

            var collision = inputPool.CreateEntity()
                .AddCollision(bullet, enemy);

            // when
            system.Execute();

            // then
            enemy.health.value.should_be(0);
        };
    }
}

