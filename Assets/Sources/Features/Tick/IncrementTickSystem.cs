using Entitas;

public sealed class IncrementTickSystem : ISetPools, IInitializeSystem, IExecuteSystem {

    Pools _pools;

    public void SetPools(Pools pools) {
        _pools = pools;
    }

    public void Initialize() {
        _pools.input.SetTick(0);
    }

    public void Execute() {
        _pools.input.ReplaceTick(_pools.input.tick.value + 1);
    }
}
