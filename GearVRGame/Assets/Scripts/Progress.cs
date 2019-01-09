using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

    public static int progress = 100;
    public Slider progressBar;

    public static bool TVOn = true;
    public static bool TVStage1 = false;
    public static bool TVStage2 = true;

    private void Start()
    {
        InvokeRepeating("EnergyCheck", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update () {
        progressBar.value = progress;
	}

    void EnergyCheck()
    {
        if (TVOn)
        {
            if (TVStage1)
            {
                progress -= 1;
            }
            if (TVStage2)
            {
                progress -= 2;
            }
        }
    }
}
