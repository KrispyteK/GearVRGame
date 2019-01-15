using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ApplianceState : MonoBehaviour {

    [Tooltip("How much energy has been wasted until now.")]
    public float EnergyWastage = 0;

    [Tooltip("The time between each energy-waste event.")]
    public float TimeBetweenWastage = 4f;

    private EffectHandler effects;

    void Start () {
        OnEnable();

        effects = transform.parent.Find("Effects").GetComponent<EffectHandler>();
    }

	void OnEnable () {
        StartCoroutine(WasteEnergy());
	}

    IEnumerator WasteEnergy () {
        while (true) {
            yield return new WaitForSeconds(TimeBetweenWastage);

            if (GameManager.Instance != null) {
                effects.DoEffect(EnergyWastage);

                GameManager.Instance.AddEnergyWaste(EnergyWastage);
            }
        }
    }

#if UNITY_EDITOR
    [MenuItem("Appliances/Create State")]
    public static void CreateApplianceState () {
        if (!(Selection.activeObject is GameObject)) {
            throw new System.Exception("Please select an appliance GameObject.");
        }

        var parent = (Selection.activeObject as GameObject).transform.root.gameObject;

        if (parent.tag != "Appliance") {
            throw new System.Exception("Appliance states have to be attached to appliances.");
        }

        // Create a custom game object
        var gameObject = new GameObject("Appliance State");
        gameObject.AddComponent<ApplianceState>();
        gameObject.tag = "ApplianceState";

        // Ensure it gets reparented if this was a context click (otherwise does nothing)
        GameObjectUtility.SetParentAndAlign(gameObject, parent);

        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);
        Selection.activeObject = gameObject;

        parent.GetComponent<Appliance>().InitialiseStates();
    }
#endif
}
