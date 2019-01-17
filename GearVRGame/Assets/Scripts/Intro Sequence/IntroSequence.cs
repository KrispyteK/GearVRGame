using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSequence : MonoBehaviour {

    public AudioSource IntroAudioSource;
    public RoofAnimation RoofAnimation;

	void Update () {
		if (!IntroAudioSource.isPlaying && !GameManager.Instance.GamePlayStarted) {
            RoofAnimation.StartedAnimation = true;
        }
	}
}
