using Entitas;

public class CreateEnemySystem : IExecuteSystem, ISetPool {

    Pool _inputPool;
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public CreateEnemySystem(Pool inputPool) {
        _inputPool = inputPool;
    }

    public void Execute() {

        // TODO Interval should be configurable
        if (_inputPool.tick.value % 10 == 0) {
            _pool.CreateEnemy0();
        }
    }
}

