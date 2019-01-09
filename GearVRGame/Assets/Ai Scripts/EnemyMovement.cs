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


    public Vector3 goal;
    GameObject[] stuff;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stuff = GameObject.FindGameObjectsWithTag("Appliance");

    }
    private void Update()
    {
        
        if (agent.velocity.x == 0 && agent.velocity.y == 0 && agent.velocity.z == 0)
        {
            GetRandomLocation();
            setDestinationB();
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
            Debug.Log(point);
            goal = point;
            return goal;
       
    }

    void setDestinationB()
    {
        agent.destination = goal;
    }

}


