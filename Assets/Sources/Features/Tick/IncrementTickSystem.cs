using Entitas;

public class IncrementTickSystem : IInitializeSystem, IExecuteSystem, ISetPool {
    
    Pool _pool;

    public void SetPool(Pool pool) {
        _pool = pool;
    }

    public void Initialize() {
        _pool.SetTick(0);
    }

    public void Execute() {
        _pool.ReplaceTick(_pool.tick.value + 1);
    }
}

