using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ApplianceState : MonoBehaviour {

    [Tooltip("How much energy has been wasted until now.")]
    public float EnergyWastage = 0;

    // Use this for initialization
    void Start () {
        print(GameManager.Instance);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    [MenuItem("Appliances/Create Appliance State")]
    static void CreateApplianceState () {
        // Create a custom game object
        var gameObject = new GameObject("Appliance State");
        gameObject.AddComponent<ApplianceState>();

        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(gameObject, Selection.activeObject as GameObject);

        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);
        Selection.activeObject = gameObject;
    }
}
