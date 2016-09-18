using Entitas;


// TODO Unit Test
public sealed class BulletCoolDownSystem : ISetPools, IExecuteSystem {

    Group _coolDowns;

    public void SetPools(Pools pools) {
        _coolDowns = pools.core.GetGroup(CoreMatcher.BulletCoolDown);
    }

    public void Execute() {
        foreach(var e in _coolDowns.GetEntities()) {
            var ticks = e.bulletCoolDown.ticks - 1;
            if(ticks > 0) {
                e.ReplaceBulletCoolDown(ticks);
            } else {
                e.RemoveBulletCoolDown();
            }
        }
    }
}
