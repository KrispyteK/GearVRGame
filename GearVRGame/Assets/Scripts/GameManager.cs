using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Tooltip("The amount of energy needed to trigger a game-over event.")]
    public float TargetEnergy = 10000;

    [Tooltip("How much energy has been wasted until now.")]
    public float EnergyWastage = 0;

    [Tooltip("Modifier that influences how much energy will be wasted.")]
    public float EnergyWasteMultiplier = 1f;

    void Awake () {
        var gameManagers = FindObjectsOfType<GameManager>();

        if (gameManagers.Length > 1) {
            Debug.LogError("More than 1 GameManager in scene");
        }
    }

    public void AddEnergyWaste (float amount) {
        EnergyWastage += amount * EnergyWasteMultiplier;

        if (EnergyWastage >= TargetEnergy) {
            DoGameOverEvent();
        }
    }

    void DoGameOverEvent () {

    }
   

    public static GameManager Instance { 
        get {
            return FindObjectOfType<GameManager>();
        }
    }
}
