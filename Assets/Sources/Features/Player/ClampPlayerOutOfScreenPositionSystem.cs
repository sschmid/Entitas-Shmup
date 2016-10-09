using Entitas;
using UnityEngine;

public sealed class ClampPlayerOutOfScreenPositionSystem : ISetPools, IExecuteSystem {

    Group _players;

    public void SetPools(Pools pools) {
        _players = pools.core.GetGroup(Matcher.AllOf(CoreMatcher.Player, CoreMatcher.Position));
    }

    public void Execute() {
        // TODO Define OutOfScreen Ofsset
        var topOffset= 5f;
        var bottomOffset = 2f;
        var leftOffset =  2f;
        var rightOffset = 2f;

        var cam = Camera.main; 

        foreach(var e in _players.GetEntities()) {

            var pos = e.position.value;

            var z = pos.z - cam.transform.position.z; 

            var frustrumPositionTopY  = cam.ViewportToWorldPoint(new Vector3(0,1,z)).y;
            var frustrumPositionBottomY  = cam.ViewportToWorldPoint(new Vector3(0,0,z)).y;
            var frustrumPositionLeftX = cam.ViewportToWorldPoint(new Vector3(0,0,z)).x;
            var frustrumPositionRightX  = cam.ViewportToWorldPoint(new Vector3(1,0,z)).x;

            pos.x = Mathf.Clamp(pos.x, frustrumPositionLeftX - leftOffset, frustrumPositionRightX + rightOffset);
            pos.y = Mathf.Clamp(pos.y, frustrumPositionBottomY - bottomOffset, frustrumPositionTopY + topOffset);

            if (pos.x != e.position.value.x || pos.y != e.position.value.y ) {
                e.ReplacePosition(pos);
            }
        }
    }
}
