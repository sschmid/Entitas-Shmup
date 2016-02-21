using Entitas;

public static class Pools {

    static Pool[] _allPools;

    public static Pool[] allPools {
        get {
            if (_allPools == null) {
                _allPools = new [] { core };
            }

            return _allPools;
        }
    }

    static Pool _core;

    public static Pool core {
        get {
            if (_core == null) {
                _core = new Pool(CoreComponentIds.TotalComponents, 0, new PoolMetaData("Core Pool", CoreComponentIds.componentNames));
                #if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
                var poolObserver = new Entitas.Unity.VisualDebugging.PoolObserver(_core, CoreComponentIds.componentTypes);
                UnityEngine.Object.DontDestroyOnLoad(poolObserver.entitiesContainer);
                #endif
            }

            return _core;
        }
    }
}