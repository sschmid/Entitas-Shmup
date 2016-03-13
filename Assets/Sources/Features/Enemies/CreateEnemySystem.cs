using Entitas;

public class CreateEnemySystem : IInitializeSystem, ISetPool {

    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.CreateEnemy0();
    }
}

