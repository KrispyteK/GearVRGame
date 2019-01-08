using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Appliance : MonoBehaviour, IInteractable {

    [HideInInspector] public List<GameObject> StateObjects = new List<GameObject>();
    [HideInInspector] public int CurrentStateIndex = 0;
    [HideInInspector] public GameObject CurrentStateObject;

    void Start () {
        for (var i = 0; i < transform.childCount; i++) {
            var child = transform.GetChild(i).gameObject;

            if (child.tag == "ApplianceState") {
                StateObjects.Add(child);
                child.SetActive(false);
            }
        }

        CurrentStateObject = StateObjects[0];
        CurrentStateObject.SetActive(true);
    }

    public void ResetState () {
        CurrentStateIndex = 0;

        SetCurrentStateObject();
    }

    public void IncreaseState () {
        if (CurrentStateIndex == StateObjects.Count - 1) return;

        CurrentStateIndex++;

        SetCurrentStateObject();
    }

    public void DecreaseState() {
        if (CurrentStateIndex == 0) return;

        CurrentStateIndex--;

        SetCurrentStateObject();
    }

    void SetCurrentStateObject () {
        CurrentStateObject.SetActive(false);
        CurrentStateObject = StateObjects[CurrentStateIndex];
        CurrentStateObject.SetActive(true);
    }

    public void OnInteract() {
        ResetState();
    }

    [MenuItem("Appliances/Create Appliance")]
    static void CreateApplianceState() {
        // Create a custom game object
        var gameObject = new GameObject("Appliance");
        gameObject.AddComponent<Appliance>();
        gameObject.tag = "Appliance";

        // Create appliance state and parent that to the object
        ApplianceState.CreateApplianceState();
        GameObjectUtility.SetParentAndAlign(Selection.activeObject as GameObject, gameObject);

        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);
        Selection.activeObject = gameObject;
    }
}
