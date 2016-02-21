using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        _systems = createSystems(Pools.core, Pools.input);
        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
    }

    Systems createSystems(Pool corePool, Pool inputPool) {
        #if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
        return new Entitas.Unity.VisualDebugging.DebugSystems()
        #else
        return new Systems()
        #endif

        // Initialize
        .Add(corePool.CreateSystem<CreatePlayerSystem>())

        // Update
        .Add(inputPool.CreateSystem(new ProcessMoveInputSystem(corePool)))
        .Add(corePool.CreateSystem<AddViewSystem>())
        .Add(corePool.CreateSystem<RenderPositionSystem>());
    }
}
