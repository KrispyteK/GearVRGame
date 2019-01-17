using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofAnimation : MonoBehaviour {

    public float TotalTime = 4f;
    public float T;
    public bool StartedAnimation = false;
    private Vector3 startScale;

    void Start () {
        startScale = transform.GetChild(0).localScale;
    }
	
	void Update () {
		if (StartedAnimation) {
            T += Time.deltaTime * 1/TotalTime;

            foreach (Transform child in transform) {
                child.localScale = startScale * (1f - Mathf.Clamp01(T));
            }

            transform.localPosition = new Vector3(0, T * 10f, 0);

            if (T > 1) {
                gameObject.SetActive(false);

                if (!GameManager.Instance.GamePlayStarted) {
                    GameManager.Instance.SetGameStarted(true);
                }
            }
        }
	}

       
}
