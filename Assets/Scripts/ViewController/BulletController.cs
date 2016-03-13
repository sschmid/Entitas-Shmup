public interface IBulletController : IViewController {
}

public class BulletController : ViewController, IBulletController {

    public override void Despawn() {
        var link = gameObject.GetEntityLink();
        link.entity.gameObjectObjectPool.pool.Push(gameObject);
        gameObject.Unlink();
        gameObject.SetActive(false);
    }
}
