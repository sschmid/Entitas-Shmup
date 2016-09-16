using Entitas;

public sealed class CreateEnemySystem : ISetPools, IExecuteSystem {

    Pools _pools;

    public void SetPools(Pools pools) {
        _pools = pools;
    }

    public void Execute() {

        // TODO Interval should be configurable
        // WaveInfo?
        if(_pools.input.tick.value % 10 == 0) {
            _pools.blueprints.blueprints.blueprints.ApplyEnemy(_pools.core.CreateEntity());
        }
    }
}
