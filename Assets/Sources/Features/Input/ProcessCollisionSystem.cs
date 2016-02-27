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
            e.collision.target.flagDestroy = true;
            _pool.DestroyEntity(e);
        }
    }
}