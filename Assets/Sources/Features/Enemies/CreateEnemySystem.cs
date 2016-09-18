using Entitas;

public sealed class CreateEnemySystem : ISetPools, IExecuteSystem {

    Pools _pools;

    public void SetPools(Pools pools) {
        _pools = pools;
    }

    public void Execute() {

        // TODO Interval should be configurable
        if(_pools.input.tick.value % 60 == 0) {
            _pools.blueprints.blueprints.instance
                  .ApplyEnemy(_pools.core.CreateEntity());
        }
    }
}
