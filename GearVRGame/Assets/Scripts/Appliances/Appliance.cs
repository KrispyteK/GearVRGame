using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Appliance : MonoBehaviour, IInteractable {

    [HideInInspector] public List<GameObject> StateObjects = new List<GameObject>();
    [HideInInspector] public int CurrentStateIndex = 0;
    [HideInInspector] public GameObject CurrentStateObject;

    public bool IsAtMaxState () {
        return CurrentStateIndex == StateObjects.Count - 1;
    }

    void Start () {
        InitialiseStates();
    }

    public void InitialiseStates () {
        StateObjects.Clear();

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

#if UNITY_EDITOR
    [MenuItem("Appliances/Create Appliance")]
    static void CreateApplianceState() {
        // Create a custom game object
        var gameObject = new GameObject("Appliance");
        gameObject.AddComponent<Appliance>();
        gameObject.tag = "Appliance";
        gameObject.layer = LayerMask.NameToLayer("Appliance");

        Selection.activeObject = gameObject;

        // Create appliance state and parent that to the object
        ApplianceState.CreateApplianceState();
        GameObjectUtility.SetParentAndAlign(Selection.activeObject as GameObject, gameObject);

        // Register the creation in the undo system
        Undo.RegisterCreatedObjectUndo(gameObject, "Create " + gameObject.name);

        Selection.activeObject = gameObject;
    }
#endif
}
