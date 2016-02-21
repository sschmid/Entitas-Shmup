using Entitas;
using UnityEngine;

public class CreatePlayerSystem : IInitializeSystem, ISetPool {

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEntity()
            .AddResource(Res.Spaceship)
            .AddPosition(Vector3.zero);
    }
}

