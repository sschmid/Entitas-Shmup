using System.Collections.Generic;
using Entitas;

public class StartEnemyWaveSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.View, CoreMatcher.Enemy).OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var enemyViewController = (IEnemyController)e.view.controller;
            enemyViewController.Init(1);
        }
    }
}