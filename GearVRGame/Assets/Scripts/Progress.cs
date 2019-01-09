using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

    public GameManager GameManager;
    static Slider progressBar;

    // Update is called once per frame
    void Update () {
        progressBar.value = (GameManager.TargetEnergy - GameManager.EnergyWastage) / GameManager.TargetEnergy * 100;
	}

}
