using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

    public Slider progressBar;
    GameManager GameManager;

    void Start () {
        GameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update () {
        progressBar.value = (GameManager.TargetEnergy - GameManager.EnergyWastage) / GameManager.TargetEnergy * 100;
	}

}
