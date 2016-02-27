using System;
using System.Collections.Generic;
using Entitas;

public class ProcessCollisionSystem : IReactiveSystem, ISetPool {

    public TriggerOnEvent trigger { get { return InputMatcher.Collision.OnEntityAdded(); } }

    Pool _pool;

    void ISetPool.SetPool(Pool pool) {
        _pool = pool;
    }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            e.collision.bullet.flagDestroy = true;
            var newHealth = Math.Max(0, e.collision.target.health.value - e.collision.bullet.damage.value);
            e.collision.target.ReplaceHealth(newHealth);
            _pool.DestroyEntity(e);
        }
    }
}