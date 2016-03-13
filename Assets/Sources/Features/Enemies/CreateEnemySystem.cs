using Entitas;
using UnityEngine;

public class CreateEnemySystem : IInitializeSystem, IReactiveSystem, ISetPool {

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {

        // TODO Remove, just for testing
        Random.seed = 0;

        for (int i = 0; i < 100; i++) {
            _pool.CreateEnemy0(new Vector3(-5f + Random.value * 10f, 2 + Random.value * 5f, 0f));
        }
    }

    public void Execute(System.Collections.Generic.List<Entity> entities) {
        foreach (var e in entities) {
            _pool.CreateEnemy0(new Vector3(-5f + Random.value * 10f, 2 + Random.value * 5f, 0f));
        }
    }
        
    public TriggerOnEvent trigger {
        get {
            return CoreMatcher.Destroy.OnEntityAdded();
        }
    }
}

