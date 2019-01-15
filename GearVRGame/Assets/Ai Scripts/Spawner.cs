using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject Enemy;
    private float timeSpawn;
    public float startTimeSpawn;
    static public float enemyCount;
    public float maxEnemyCount = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

       
		if (enemyCount < maxEnemyCount)
        {
            if (timeSpawn <= 0)
            {

                Instantiate(Enemy, transform.position, Quaternion.identity);
                timeSpawn = startTimeSpawn;
                enemyCount++;
            }
            else
            {
                timeSpawn -= Time.deltaTime;
            }
        }
	}
}
