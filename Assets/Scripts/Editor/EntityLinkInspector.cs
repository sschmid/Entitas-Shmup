using System.Linq;
using Entitas.Unity.VisualDebugging;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EntityLink))]
public class EntityLinkInspector : Editor {

    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        var link = (EntityLink)target;
        EditorGUILayout.LabelField(link.entity.ToString());

        if (GUILayout.Button("Show entity")) {
            Selection.activeGameObject = Object.FindObjectsOfType<EntityBehaviour>()
                .Single(e => e.entity == link.entity).gameObject;
        }
    }
}
