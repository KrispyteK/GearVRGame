using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ApplianceState : MonoBehaviour {

    [Tooltip("How much energy has been wasted until now.")]
    public float EnergyWastage = 0;

    [Tooltip("The time between each energy-waste event.")]
    public float TimeBetweenWastage = 4f;

    void Start () {
        OnEnable();
	}

	void OnEnable () {
        StartCoroutine(WasteEnergy());
	}

    IEnumerator WasteEnergy () {
        while (true) {
            yield return new WaitForSeconds(TimeBetweenWastage);

            GameManager.Instance.AddEnergyWaste(EnergyWastage);
        }
    }

    [MenuItem("Appliances/Create State")]
    public static void CreateApplianceState () {
        // Create a custom game object
        var gameObject = new GameObject("Appliance State");
        gameObject.AddComponent<ApplianceState>();
        gameObject.tag = "ApplianceState";

        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(gameObject, (Selection.activeObject as GameObject).transform.root.gameObject);

        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);
        Selection.activeObject = gameObject;
    }
}
