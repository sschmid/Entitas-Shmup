﻿using NSpec;
using Entitas;
using UnityEngine;

class describe_DestroyBulletsSystem : nspec {

    void when_executing() {

        it["destroys bullet when out of screen"] = () => {

            // given
            var pool = TestHelper.CreateBulletPool();
            var bullet = pool.CreateEntity()
                .IsBullet(true)
                .AddPosition(Vector3.one);

            var system = (IExecuteSystem)pool.CreateSystem<DestroyBulletOutOfScreenSystem>();

            system.Execute();
            bullet.flagDestroy.should_be_false();

            // when bullet out of screen
            bullet.ReplacePosition(new Vector3(1, 100f, 0));
            system.Execute();

            bullet.flagDestroy.should_be_true();
        };
    }
}

