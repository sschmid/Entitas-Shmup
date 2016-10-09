using Entitas;
using UnityEngine;
using System.Collections.Generic;

public sealed class CreatePlayerSystem : ISetPools, IInitializeSystem, IReactiveSystem {
    

    public TriggerOnEvent trigger { get { return CoreMatcher.Player.OnEntityRemoved(); } }

    Pools _pools;

    public void SetPools(Pools pools) {
        _pools = pools;
    }

    public void Initialize() {
        _pools.blueprints.blueprints.instance
              .ApplyPlayer1(_pools.core.CreateEntity(), Vector3.zero);
    }
        
    public void Execute (List<Entity> entities)
    {
        _pools.blueprints.blueprints.instance
            .ApplyPlayer1(_pools.core.CreateEntity(), Vector3.zero);
    }
}
