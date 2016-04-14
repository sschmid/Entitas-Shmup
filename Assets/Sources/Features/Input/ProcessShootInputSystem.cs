using System.Collections.Generic;
using Entitas;
using Entitas.Unity.Serialization.Blueprints;
using UnityEngine;

public class ProcessShootInputSystem : IReactiveSystem, ISetPool {

    public TriggerOnEvent trigger { get { return InputMatcher.ShootInput.OnEntityAdded(); } }

    Pool _inputPool;
    readonly Group _players;
    readonly Pool _bulletsPool;
    readonly Blueprints _blueprints;

    readonly ObjectPool<GameObject> _bulletsObjectPool;

    public void SetPool(Pool pool) {
        _inputPool = pool;
    }

    public ProcessShootInputSystem(Pool corePool, Pool bulletsPool, Blueprints blueprints) {
        _players = corePool.GetGroup(Matcher.AllOf(CoreMatcher.Player, CoreMatcher.Position));
        _bulletsPool = bulletsPool;
        _blueprints = blueprints;
        _bulletsObjectPool = new ObjectPool<GameObject>(() => Assets.Instantiate<GameObject>(Res.Bullet));
    }

    public void Execute(List<Entity> entities) {
        var input = entities[entities.Count - 1];
        var ownerId = input.inputOwner.playerId;

        // TODO Remove, just for testing
        if (Pools.input.tick.value % 5 == 0) {

            foreach (var e in _players.GetEntities()) {
                if (e.player.id == ownerId) {
                    // TODO Remove, just for testing
                    var velX = -0.02f + Random.value * 0.04f;
                    var velY = 0.3f + Random.value * 0.2f;
                    var velocity = new Vector3(velX, velY, 0);
//                var velocity = new Vector3(0, 0.5f, 0);
                    _blueprints.ApplyBullet(_bulletsPool.CreateEntity(), e.position.value, velocity, _bulletsObjectPool);
                }
            }
        }

        _inputPool.DestroyEntity(input);
    }
}
