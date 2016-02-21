using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour {

    Systems _systems;

    void Start() {
        _systems = createSystems(Pools.core);
        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
    }

    Systems createSystems(Pool pool) {
        #if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
        return new Entitas.Unity.VisualDebugging.DebugSystems()
        #else
        return new Systems()
        #endif

        // Initialize
        .Add(pool.CreateSystem<CreatePlayerSystem>())

        // Update
        .Add(pool.CreateSystem<AddViewSystem>());
    }
}
