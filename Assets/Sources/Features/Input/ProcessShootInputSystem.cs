using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ProcessShootInputSystem : IReactiveSystem, ISetPool {

    public TriggerOnEvent trigger { get { return InputMatcher.ShootInput.OnEntityAdded();}}

    Pool _inputPool;
    readonly Group _players;
    readonly Pool _bulletsPool;

    public void SetPool(Pool pool) {
        _inputPool = pool;
    }

    public ProcessShootInputSystem(Pool corePool, Pool bulletsPool) {
        _players = corePool.GetGroup(Matcher.AllOf(CoreMatcher.Player, CoreMatcher.Position));
        _bulletsPool = bulletsPool;
    }

    public void Execute(List<Entity> entities) {
        var input = entities.SingleEntity();
        var ownerId = input.inputOwner.playerId;

        foreach (var e in _players.GetEntities()) {
            if (e.player.id == ownerId) {
                _bulletsPool.CreateEntity()
                    .IsBullet(true)
                    .AddPosition(e.position.value)
                    .AddVelocity(new Vector3(0, 1f, 0))
                    .AddResource(Res.Bullet);
            }
        }

        _inputPool.DestroyEntity(input);
    }
}
