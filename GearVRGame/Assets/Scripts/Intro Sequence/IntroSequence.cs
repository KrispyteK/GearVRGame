using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequence : MonoBehaviour {

    public RoofAnimation RoofAnimation;
    private AudioSource IntroAudioSource;

    void Start () {
        IntroAudioSource = GetComponent<AudioSource>();
    }

	void Update () {
		if (!IntroAudioSource.isPlaying && !GameManager.Instance.GamePlayStarted) {
            RoofAnimation.StartedAnimation = true;
        }
	}
}
