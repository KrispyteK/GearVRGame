using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


    public GameObject Enemy;
    public int EnemyCount;

	void Start () {
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies () {
        while (true) {
            EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (EnemyCount < GameManager.Instance.MaxEnemyCount) {
                Instantiate(Enemy, transform.position, Quaternion.Euler(0, 0, 0));
            }

            yield return new WaitForSeconds(GameManager.Instance.EnemySpawnTime);
        }
    }
}
