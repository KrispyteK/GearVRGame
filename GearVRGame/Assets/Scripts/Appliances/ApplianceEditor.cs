using UnityEngine;
using System.Collections;
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