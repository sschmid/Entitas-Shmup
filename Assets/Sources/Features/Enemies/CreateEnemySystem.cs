using Entitas;

public class CreateEnemySystem : IExecuteSystem {

    readonly Pool _corePool;
    readonly Pool _inputPool;

    public CreateEnemySystem(Pool corePool, Pool inputPool) {
        _corePool = corePool;
        _inputPool = inputPool;
    }

    public void Execute() {

        // TODO Interval should be configurable
        if (_inputPool.tick.value % 10 == 0) {
            _corePool.CreateEnemy0();
        }
    }
}

