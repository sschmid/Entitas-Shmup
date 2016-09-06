using NSpec;
using Entitas;
using UnityEngine;

class describe_BulletOutOfScreenSystem : nspec {

    void when_executing() {

        it["destroys bullet when out of screen"] = () => {

            // given
            var pool = TestHelper.CreateBulletsPool();
            var bullet = pool.CreateEntity()
                .IsBullet(true)
                .AddPosition(Vector3.one);

            var system = (IExecuteSystem)pool.CreateSystem(new BulletOutOfScreenSystem());

            // when bullet is in screen
            system.Execute();
            bullet.isOutOfScreen.should_be_false();
            bullet.flagDestroy.should_be_false();

            // when bullet out of screen
            bullet.ReplacePosition(new Vector3(1, 100f, 0));
            system.Execute();

            bullet.flagDestroy.should_be_false();
            bullet.isOutOfScreen.should_be_true();
        };
    }
}

