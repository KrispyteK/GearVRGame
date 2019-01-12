using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour {

    AudioSource audioSource;
    ParticleSystem emitter;

	void Start () {
        audioSource = GetComponent<AudioSource>();
        emitter = GetComponent<ParticleSystem>();

        audioSource.Stop();
        emitter.Stop();
    }


	public void DoEffect (float energy) {
        var main = emitter.main;
        main.startSize = energy / 500;

        audioSource.Play();

        emitter.Clear();
        emitter.Play();
    }
}
