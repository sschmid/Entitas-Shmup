using Entitas;
using UnityEngine;

public class CreateEnemySystem : IInitializeSystem, ISetPool {

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEntity()
            .AddResource(Res.Enemy0)
            .AddPosition(new Vector3(0f, 3f, 0f));
    }
}

