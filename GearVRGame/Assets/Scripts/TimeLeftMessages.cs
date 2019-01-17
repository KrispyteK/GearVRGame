using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLeftMessages : MonoBehaviour {

    public int TimeGap = 60;
    public AudioClip[] AudioClips;

    private AudioSource audioSource;
    private int nextIndex = 0;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        float timeIndex = GameManager.Instance.TotalTime / TimeGap;

        if (timeIndex > nextIndex && nextIndex < AudioClips.Length) {
            audioSource.clip = AudioClips[nextIndex];
            audioSource.Play();

            nextIndex++;
        }
    }
}