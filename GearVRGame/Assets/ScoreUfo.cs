using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUfo : MonoBehaviour {

    public Renderer render;
    GameManager GameManager;
    public float energyWaster;
    float cutOffValue;

    void Start()
    {
        GameManager = GameManager.Instance;
        render = GetComponent<Renderer>();
    }


	
	// Update is called once per frame
	void Update ()
    {
        cutOffValue = 1/GameManager.TargetEnergy * GameManager.EnergyWastage;

        render.material.SetFloat("_Cutoff", 1-cutOffValue);
    }
}
