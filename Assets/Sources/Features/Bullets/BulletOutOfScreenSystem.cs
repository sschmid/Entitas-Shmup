using Entitas;

public class BulletOutOfScreenSystem : IExecuteSystem, ISetPool {

    Group _bullets;

    public void SetPool(Pool pool) {
        _bullets = pool.GetGroup(Matcher.AllOf(BulletsMatcher.Bullet, BulletsMatcher.Position));
    }

    public void Execute() {
        foreach (var e in _bullets.GetEntities()) {

            // TODO Define OutOfScreen Y position
            // TODO When OutOfScreen at the bottom

            if (e.position.value.y > 20f) {
                e.isOutOfScreen = true;
            }
        }
    }
}