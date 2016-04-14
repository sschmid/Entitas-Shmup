using Entitas;
using UnityEngine;

namespace Entitas.Unity.Serialization.Blueprints {

    public partial class Blueprints {

        public Entity ApplyBullet(Entity entity, Vector3 position, Vector3 velocity, ObjectPool<GameObject> gameObjectPool) {
            return entity.ApplyBlueprint(Bullet)
                .AddPosition(position)
                .AddVelocity(velocity)
                .AddViewObjectPool(gameObjectPool);
        }

        public Entity ApplyEnemy0(Entity entity) {
            return entity.ApplyBlueprint(Enemy0);
        }
    }
}