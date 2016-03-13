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
            .Add(corePool.CreateSystem<CreatePlayerSystem>())
            .Add(corePool.CreateSystem<CreateEnemySystem>())
            .Add(corePool.CreateSystem<AddViewSystem>())
            .Add(bulletsPool.CreateSystem<AddViewFromObjectPoolSystem>())

            .Add(corePool.CreateSystem<StartEnemyWaveSystem>())

            // Input
            .Add(inputPool.CreateSystem(new ProcessMoveInputSystem(corePool)))
            .Add(inputPool.CreateSystem(new ProcessShootInputSystem(corePool, bulletsPool)))
            .Add(inputPool.CreateSystem<ProcessCollisionSystem>())

            // Update
            .Add(corePool.CreateSystem<VelocitySystem>())
            .Add(bulletsPool.CreateSystem<VelocitySystem>())
            .Add(corePool.CreateSystem<RenderPositionSystem>())
            .Add(bulletsPool.CreateSystem<RenderPositionSystem>())
            
            .Add(corePool.CreateSystem<CheckHealthSystem>())
            .Add(bulletsPool.CreateSystem<DestroyBulletOutOfScreenSystem>())

            // Destroy
            .Add(corePool.CreateSystem<DestroyViewSystem>())
            .Add(bulletsPool.CreateSystem<DestroyViewSystem>())

            .Add(corePool.CreateSystem<DestroySystem>())
            .Add(bulletsPool.CreateSystem<DestroySystem>());
    }
}

