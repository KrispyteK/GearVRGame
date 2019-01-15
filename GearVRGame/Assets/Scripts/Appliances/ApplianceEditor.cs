using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Appliance))]
public class ApplianceEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        var appliance = (Appliance)target;
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Increase state")) {
            appliance.IncreaseState();
        }

        if (GUILayout.Button("Decrease state")) {
            appliance.DecreaseState();
        }

        GUILayout.EndHorizontal();
    }
}
#else
public class ApplianceEditor {}
#endif