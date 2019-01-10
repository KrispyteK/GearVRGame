using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour {

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    public bool gettingNewLocation;

    public bool letsGo;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Start walking when we spawn
        StartCoroutine(NextLocation());
    }

    private void Update() {

        if (!agent.hasPath) {
            print(GetComponent<AIIncreasingState>().IsAffectingAppliance);

            if (!GetComponent<AIIncreasingState>().IsAffectingAppliance) {
                GetComponent<AIIncreasingState>().CheckForAppliances();
            } else if (!gettingNewLocation) {
                StartCoroutine(NextLocation());
            }
        }

    }

    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;       
    }

    public IEnumerator NextLocation() {
        gettingNewLocation = true;

        // Wait for a random time between 1 and 2 seconds
        yield return new WaitForSeconds(Random.Range(1f,2f));

        // After waiting go to a new location
        agent.destination = GetRandomLocation();
        gettingNewLocation = false;
    }

}


