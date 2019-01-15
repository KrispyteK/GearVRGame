﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [Tooltip("The amount of energy needed to trigger a game-over event.")]
    public float TargetEnergy = 10000f;

    [Tooltip("How much energy has been wasted until now.")]
    public float EnergyWastage = 0f;

    [Tooltip("Modifier that influences how much energy will be wasted.")]
    public float EnergyWasteMultiplier = 1f;

    [Tooltip("Time between each enemy spawn event.")]
    public float EnemySpawnTime = 5f;

    [Tooltip("How many enemies can be in the scene at once.")]
    public float MaxEnemyCount = 10f;

    public static GameManager Instance;

    void Awake () {
        var gameManagers = FindObjectsOfType<GameManager>();

        if (gameManagers.Length > 1) {
            Debug.LogError("More than 1 GameManager in scene");
        } else {
            Instance = this;
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
}
