using Entitas;
using Entitas.Unity.Serialization.Blueprints;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Blueprints blueprints;

    Systems _systems;

    void Awake() {
        Application.targetFrameRate = 60;
    }

    void Start() {

        GameRandom.core = new Rand(0);
        GameRandom.view = new Rand(0);

        var pools = Pools.sharedInstance;
        pools.SetAllPools();
        pools.AddEntityIndices();

        pools.blueprints.SetBlueprints(blueprints);

        _systems = createSystems(pools);

        // Suggested systems lifecycle:
        // systems.Initialize() on Start
        // systems.Execute() on Update
        // systems.Cleanup() on Update after systems.Execute()
        // systems.TearDown() on OnDestroy

        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
        _systems.Cleanup();
    }

    void OnDestroy() {
        _systems.TearDown();
    }

    Systems createSystems(Pools pools) {
        return new Feature("Systems")

            // Initialize
            .Add(pools.CreateSystem(new IncrementTickSystem()))
            .Add(pools.core.CreateSystem(new CreatePlayerSystem()))
            .Add(pools.CreateSystem(new CreateEnemySystem()))

            .Add(pools.core.CreateSystem(new AddViewSystem()))
            .Add(pools.bullets.CreateSystem(new AddViewFromObjectPoolSystem()))

            // Input
            .Add(pools.CreateSystem(new InputSystem()))
            .Add(pools.input.CreateSystem(new ProcessMoveInputSystem()))
            .Add(pools.input.CreateSystem(new ProcessShootInputSystem()))
            .Add(pools.input.CreateSystem(new ProcessCollisionSystem()))
            .Add(pools.input.CreateSystem(new SlowMotionSystem()))

            // Update
            .Add(pools.core.CreateSystem(new BulletCoolDownSystem()))
            .Add(pools.core.CreateSystem(new StartEnemyWaveSystem()))
            .Add(pools.CreateSystem(new VelocitySystem()))
            .Add(pools.core.CreateSystem(new ClampPlayerOutOfScreenPositionSystem()))
            .Add(pools.CreateSystem(new RenderPositionSystem()))
            .Add(pools.core.CreateSystem(new CheckHealthSystem()))
            .Add(pools.bullets.CreateSystem(new BulletOutOfScreenSystem()))

            // Animate Destroy
            .Add(pools.CreateSystem(new AnimateOutOfScreenViewSystem()))
            .Add(pools.CreateSystem(new AnimateDestroyViewSystem()))

            // Destroy
            .Add(pools.CreateSystem(new DestroyEntitySystem()));
    }
}
