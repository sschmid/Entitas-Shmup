using System;
using Entitas;
using Entitas.Unity.VisualDebugging;
using UnityEditor;
using UnityEngine;

public class ViewControllerTypeDrawer : ITypeDrawer {
    public bool HandlesType(Type type) {
        return type == typeof(IViewController);
    }

    const string MEMBER_NAME = "gameObject";

    // Draw only - no value change poosible
    public object DrawAndGetNewValue(Type memberType, string memberName, object value, Entity entity, int index, IComponent component) {
        EditorGUILayout.ObjectField(MEMBER_NAME, ((IViewController)value).gameObject, typeof(GameObject), false);
        return value;
    }
}