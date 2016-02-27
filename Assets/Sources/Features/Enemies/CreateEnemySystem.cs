using Entitas;
using UnityEngine;

public class CreateEnemySystem : IInitializeSystem, ISetPool {

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEnemy0(new Vector3(0f, 3f, 0f));
    }
}

