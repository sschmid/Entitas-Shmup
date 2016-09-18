using Entitas;
using UnityEngine;

public sealed class CreatePlayerSystem : ISetPools, IInitializeSystem {

    Pools _pools;

    public void SetPools(Pools pools) {
        _pools = pools;
    }

    public void Initialize() {
        _pools.blueprints.blueprints.instance
              .ApplyPlayer1(_pools.core.CreateEntity(), Vector3.zero);
    }
}
