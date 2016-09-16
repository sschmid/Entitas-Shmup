using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class SlowMotionSystem : IReactiveSystem {

    public TriggerOnEvent trigger { get { return InputMatcher.SlowMotion.OnEntityAddedOrRemoved(); } }

    public void Execute(List<Entity> entities) {
        Time.timeScale = entities.SingleEntity().isSlowMotion
            ? 0.3f
            : 1f;
    }
}
