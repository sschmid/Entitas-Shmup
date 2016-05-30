using Entitas;
using Entitas.Unity.Serialization.Blueprints;

public class CreateEnemySystem : IExecuteSystem {

    readonly Pool _corePool;
    readonly Pool _inputPool;
    readonly Blueprints _blueprints;

    public CreateEnemySystem(Pool corePool, Pool inputPool, Blueprints blueprints) {
        _corePool = corePool;
        _inputPool = inputPool;
        _blueprints = blueprints;
    }

    public void Execute() {

        // TODO Interval should be configurable
        // WaveInfo?
        if (_inputPool.tick.value % 10 == 0) {
            _blueprints.ApplyEnemy(_corePool.CreateEntity());
        }
    }
}

