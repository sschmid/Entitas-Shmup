using NSpec;
using Entitas;
using UnityEngine;

class describle_PoolExtensions : nspec {

    void when_creating() {

        it["creates bullet"] = () => {

            // given
            var pool = TestHelper.CreateBulletPool();
            var pos = Vector3.zero;
            var vel = Vector3.one;
            ObjectPool<GameObject> objectPool = null;

            // when
            var entity = pool.CreateBullet(pos, vel, objectPool);

            // then
            entity.isBullet.should_be_true();
            entity.position.value.should_be(pos);
            entity.velocity.value.should_be(vel);
            entity.gameObjectObjectPool.pool.should_be_same(objectPool);
            entity.damage.value.should_be(1);
        };

        it["creates enemy0"] = () => {

            // given
            var pool = TestHelper.CreateCorePool();

            // when
            var entity = pool.CreateEnemy0();

            // then
            entity.health.value.should_be(1);
            entity.resource.name.should_be(Res.Enemy0);
        };
    }
}

