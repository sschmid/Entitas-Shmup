using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class StartEnemyWaveSystem : IReactiveSystem {
    public TriggerOnEvent trigger { get { return Matcher.AllOf(CoreMatcher.View, CoreMatcher.Enemy).OnEntityAdded(); } }

    public void Execute(List<Entity> entities) {
        foreach (var e in entities) {
            var enemyViewController = (IEnemyController)e.view.controller;


            // TODO Implement own random
            enemyViewController.Init(Random.Range(1, 3));
        }
    }
}