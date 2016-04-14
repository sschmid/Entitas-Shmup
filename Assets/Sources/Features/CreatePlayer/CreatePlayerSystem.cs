using Entitas;
using UnityEngine;

public class CreatePlayerSystem : IInitializeSystem, ISetPool {

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEntity()
            .AddPlayer("Player1")
            .AddPosition(Vector3.zero)
            .AddAsset(Res.Spaceship);
    }
}

