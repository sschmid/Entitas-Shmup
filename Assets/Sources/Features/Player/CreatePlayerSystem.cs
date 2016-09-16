using Entitas;
using UnityEngine;

public sealed class CreatePlayerSystem : ISetPools, IInitializeSystem {

    Pools _pools;

    public void SetPools(Pools pools) {
        _pools = pools;
    }

    public void Initialize() {
        _pools.core.CreateEntity()
            .AddPlayer("Player1")
            .AddPosition(Vector3.zero)
            .AddAsset(Res.Spaceship);
    }
}
