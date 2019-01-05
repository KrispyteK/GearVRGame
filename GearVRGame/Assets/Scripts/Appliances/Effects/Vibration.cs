using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibration : MonoBehaviour {

    public float Amount = 1;
    public float Speed = 10;
    public float Randomness = 1;

    private Vector2 noiseVectorX;
    private Vector2 noiseVectorY;
    private Vector2 noiseVectorZ;

    private float noiseRotationX;
    private float noiseRotationY;
    private float noiseRotationZ;
	
	void Update () {
        noiseVectorX += (new Vector2(Speed, Speed) + new Vector2(Random.value, Random.value) * Randomness) * Time.deltaTime;
        noiseVectorY += (new Vector2(Speed, Speed) + new Vector2(Random.value, Random.value) * Randomness) * Time.deltaTime;
        noiseVectorZ += (new Vector2(Speed, Speed) + new Vector2(Random.value, Random.value) * Randomness) * Time.deltaTime;

        noiseRotationX = (Mathf.PerlinNoise(noiseVectorX.x, noiseVectorX.y) - 0.5f) * 2 * Amount;
        noiseRotationY = (Mathf.PerlinNoise(noiseVectorY.x, noiseVectorY.y) - 0.5f) * 2 * Amount;
        noiseRotationZ = (Mathf.PerlinNoise(noiseVectorZ.x, noiseVectorZ.y) - 0.5f) * 2 * Amount;

        transform.localRotation = Quaternion.Euler(noiseRotationX,noiseRotationY,noiseRotationZ);
    }
}
