using Entitas;

public class DestroyBulletOutOfScreenSystem : IExecuteSystem, ISetPool {

    Group _bullets;

    public void SetPool(Pool pool) {
        _bullets = pool.GetGroup(Matcher.AllOf(BulletsMatcher.Bullet, BulletsMatcher.Position));
    }

    public void Execute() {
        foreach (var e in _bullets.GetEntities()) {
            if (e.position.value.y > 20f) {
                e.isOutOfScreen = true;
                e.flagDestroy = true;
            }
        }
    }
}