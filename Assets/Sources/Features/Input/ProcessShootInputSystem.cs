using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ProcessShootInputSystem : ISetPools, IReactiveSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.ShootInput.OnEntityAdded(); } }

    Pools _pools;
    ObjectPool<GameObject> _bulletsObjectPool;

    public void SetPools(Pools pools) {
        _pools = pools;

        // TODO Put on a component
        _bulletsObjectPool = new ObjectPool<GameObject>(() => Assets.Instantiate<GameObject>(Res.Bullet));
    }

    public void Execute(List<Entity> entities) {
        var input = entities[entities.Count - 1];
        var ownerId = input.inputOwner.playerId;

        var e = _pools.core.GetEntityWithPlayerId(ownerId);
        if(!e.hasBulletCoolDown) {

            // TODO CoolDown should be configurable
            e.AddBulletCoolDown(7);

            var velX = GameRandom.core.RandomFloat(-0.02f, 0.02f);
            var velY = GameRandom.core.RandomFloat(0.3f, 0.5f);
            var velocity = new Vector3(velX, velY, 0);
            _pools.blueprints.blueprints.instance.ApplyBullet(
                _pools.bullets.CreateEntity(), e.position.value, velocity, _bulletsObjectPool
            );
        }
    }
}
