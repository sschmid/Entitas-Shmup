public interface IBulletController : IViewController {
}

public class BulletController : ViewController, IBulletController {

    public override void Despawn() {
        var link = entityLink;
        link.entity.gameObjectObjectPool.pool.Push(gameObject);
        link.Unlink();
        gameObject.SetActive(false);
    }
}
