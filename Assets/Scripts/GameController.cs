using Entitas;
using UnityEngine;
using Entitas.Unity.Serialization.Blueprints;

public class GameController : MonoBehaviour {

    public Blueprints blueprints;

    Systems _systems;

    void Awake() {
        Application.targetFrameRate = 60;
    }

    void Start() {
        _systems = createSystems(Pools.core, Pools.input, Pools.bullets);
        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
    }

    Systems createSystems(Pool corePool, Pool inputPool, Pool bulletsPool) {
        return new Feature("Systems")

            // Initialize
            .Add(inputPool.CreateSystem(new IncrementTickSystem()))
            .Add(corePool.CreateSystem(new CreatePlayerSystem()))
            .Add(new CreateEnemySystem(corePool, inputPool, blueprints))
            .Add(corePool.CreateSystem(new AddViewSystem()))
            .Add(bulletsPool.CreateSystem(new AddViewFromObjectPoolSystem()))

            // Input
            .Add(inputPool.CreateSystem(new ProcessMoveInputSystem(corePool)))
            .Add(inputPool.CreateSystem(new ProcessShootInputSystem(corePool, bulletsPool, blueprints)))
            .Add(inputPool.CreateSystem(new ProcessCollisionSystem()))

            // Update
            .Add(corePool.CreateSystem(new StartEnemyWaveSystem()))
            .Add(new VelocitySystem(corePool, bulletsPool))
            .Add(new ReactiveSystem(new RenderPositionSystem(corePool, bulletsPool)))
            .Add(corePool.CreateSystem(new CheckHealthSystem()))
            .Add(bulletsPool.CreateSystem(new BulletOutOfScreenSystem()))

            // Animate Destroy
            .Add(new ReactiveSystem(new AnimateOutOfScreenViewSystem(corePool, bulletsPool)))
            .Add(new ReactiveSystem(new AnimateDestroyViewSystem(corePool, bulletsPool)))

            // Destroy
            .Add(new ReactiveSystem(new DestroyEntitySystem(corePool, bulletsPool)));
    }
}

