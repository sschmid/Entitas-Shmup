using System;
using Entitas;
using Entitas.Unity.VisualDebugging;
using System.Reflection;
using System.Linq;
using UnityEditor;

public class AssetComponentDrawer : IComponentDrawer {

    readonly string[] _assetNames;

    public AssetComponentDrawer() {
        var type = typeof(Res);
        _assetNames = type.GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(info => (string)info.GetValue(type))
            .ToArray();
    }

    public bool HandlesType(Type type) {
        return type == typeof(AssetComponent);
    }

    public IComponent DrawComponent(IComponent component) {
        var asset = (AssetComponent)component;
        if (asset.name == null) {
            asset.name = string.Empty;
        }

        var index = Array.IndexOf(_assetNames, asset.name);
        index = EditorGUILayout.Popup("Name", index, _assetNames);

        if (index >= 0) {
            asset.name = _assetNames[index];
        }

        return asset;
    }
}
