using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour {

    public static int progress = 0;
    public Slider progressBar;

	// Update is called once per frame
	void Update () {
        progressBar.value = progress;
        print("progress " + progress);
	}
}
