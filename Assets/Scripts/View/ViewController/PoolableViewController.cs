public class PoolableViewController : ViewController, IPoolableViewController {

    public virtual void PushToObjectPool() {
        var link = gameObject.GetEntityLink();
        link.entity.viewObjectPool.pool.Push(gameObject);
    }
}
