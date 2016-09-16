using System;
using System.Collections.Generic;
using Entitas;

public sealed class ProcessCollisionSystem : ISetPool, IReactiveSystem, ICleanupSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.Collision.OnEntityAdded(); } }

    Pool _pool;
    Group _collisions;

    void ISetPool.SetPool(Pool pool) {
        _pool = pool;
        _collisions = pool.GetGroup(InputMatcher.Collision);
    }

    public void Execute(List<Entity> entities) {
        foreach(var e in entities) {
            e.collision.self.flagDestroy = true;
            var newHealth = e.collision.other.health.value - e.collision.self.damage.value;
            e.collision.other.ReplaceHealth(Math.Max(0, newHealth));
        }
    }

    public void Cleanup() {
        foreach(var e in _collisions.GetEntities()) {
            _pool.DestroyEntity(e);
        }
    }
}
