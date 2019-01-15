using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUfo : MonoBehaviour {

    public Renderer render;
    GameManager GameManager;
    float cutOffValue;

    void Start()
    {
        GameManager = GameManager.Instance;
        render = GetComponent<Renderer>();
    }


	
	// Update is called once per frame
	void Update ()
    {
        cutOffValue = (GameManager.TargetEnergy - GameManager.EnergyWastage) / GameManager.TargetEnergy;

        render.material.SetFloat("_Cutoff", cutOffValue);
    }
}
