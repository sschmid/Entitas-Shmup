using System.Collections.Generic;
using Entitas;

public class DestroyViewSystem : IReactiveSystem, IEnsureComponents {
    public TriggerOnEvent trigger { get { return CoreMatcher.Destroy.OnEntityAdded(); } }

    public IMatcher ensureComponents { get { return CoreMatcher.View; } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            if (e.hasGameObjectObjectPool) {
                var gameObject = e.view.gameObject;
                gameObject.SetActive(false);
                e.gameObjectObjectPool.pool.Push(gameObject);
            } else {
                Assets.Destroy(e.view.gameObject);
            }
        }
    }
}