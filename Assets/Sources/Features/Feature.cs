#if (!ENTITAS_DISABLE_VISUAL_DEBUGGING && UNITY_EDITOR)
public class Feature : Entitas.Systems {
    public Feature(string name) : base() {
    }
}
#else
public class Feature : Entitas.Unity.VisualDebugging.DebugSystems {
    public Feature(string name) : base(name) {
    }
}
#endif
