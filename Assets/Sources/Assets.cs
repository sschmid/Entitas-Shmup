using UnityEngine;

public static class Assets {
    public static void Destroy(Object obj) {
        #if (UNITY_EDITOR)
        if (UnityEditor.EditorApplication.isPlaying)
        {
            Object.Destroy(obj);
        } else
        {
            Object.DestroyImmediate(obj);
        }
        #else
        Object.Destroy(obj);
        #endif
    }
}

