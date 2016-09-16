using Entitas;

public sealed class BulletOutOfScreenSystem : ISetPools, IExecuteSystem {

    Group _bullets;

    public void SetPools(Pools pools) {
        _bullets = pools.bullets.GetGroup(Matcher.AllOf(BulletsMatcher.Bullet, BulletsMatcher.Position));
    }

    public void Execute() {
        foreach(var e in _bullets.GetEntities()) {

            // TODO Define OutOfScreen Y position
            // TODO When OutOfScreen at the bottom

            if(e.position.value.y > 20f) {
                e.isOutOfScreen = true;
            }
        }
    }
}
