using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEngine;

public class GameController : MonoBehaviour {

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
            .Add(inputPool.CreateSystem<IncrementTickSystem>())
            .Add(corePool.CreateSystem<CreatePlayerSystem>())
            .Add(corePool.CreateSystem(new CreateEnemySystem(inputPool)))
            .Add(corePool.CreateSystem<AddViewSystem>())
            .Add(bulletsPool.CreateSystem<AddViewFromObjectPoolSystem>())

            // Input
            .Add(inputPool.CreateSystem(new ProcessMoveInputSystem(corePool)))
            .Add(inputPool.CreateSystem(new ProcessShootInputSystem(corePool, bulletsPool)))
            .Add(inputPool.CreateSystem<ProcessCollisionSystem>())

            // Update
            .Add(corePool.CreateSystem<StartEnemyWaveSystem>())
            .Add(new VelocitySystem(corePool, bulletsPool))
            .Add(new ReactiveSystem(new RenderPositionSystem(corePool, bulletsPool)))
            .Add(corePool.CreateSystem<CheckHealthSystem>())
            .Add(bulletsPool.CreateSystem<DestroyBulletOutOfScreenSystem>())

            // Destroy
            .Add(new ReactiveSystem(new DestroyViewSystem(corePool, bulletsPool)))
            .Add(new ReactiveSystem(new DestroySystem(corePool, bulletsPool)));
    }
}

