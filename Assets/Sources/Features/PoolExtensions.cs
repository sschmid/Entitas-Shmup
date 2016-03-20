using Entitas;
using UnityEngine;

public static class PoolExtensions {

    public static Entity CreateBullet(this Pool pool, Vector3 position, Vector3 velocity, ObjectPool<GameObject> gameObjectPool) {
        return pool.CreateEntity()
            .IsBullet(true)
            .AddPosition(position)
            .AddVelocity(velocity)
            .AddDamage(1)
            .AddGameObjectObjectPool(gameObjectPool);
    }

    public static Entity CreateEnemy0(this Pool pool) {
        return pool.CreateEntity()
            .IsEnemy(true)
            .AddHealth(3)
            .AddResource(Res.Enemy0);
    }
}