using UnityEngine;

public static class Assets {

    public static T GetAsset<T>(string assetName) where T : Object {
        return Resources.Load<T>(assetName);
    }

    public static T Clone<T>(T obj) where T : Object {
        return Object.Instantiate(obj);
    }

    public static T Instantiate<T>(string assetName) where T : Object {
        return Clone(GetAsset<T>(assetName));
    }

    public static void Destroy(Object obj) {

#if(UNITY_EDITOR)

        if(UnityEditor.EditorApplication.isPlaying) {
            Object.Destroy(obj);
        } else {
            Object.DestroyImmediate(obj);
        }

#else
        
        Object.Destroy(obj);

#endif
    }

    public static void Destroy(Object obj, float delay) {
        Object.Destroy(obj, delay);
    }
}
