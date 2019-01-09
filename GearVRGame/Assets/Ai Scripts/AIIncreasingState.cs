using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIIncreasingState : MonoBehaviour {

    public LayerMask LayerMask;
    public int Radius = 100;

    [HideInInspector]
    public bool IsAffectingAppliance = false;

    private NavMeshAgent agent;
    // The appliance we previously affected
    private GameObject previousAppliance;

    void Start() {
        agent = GetComponent<NavMeshAgent>();

        IsAffectingAppliance = false;
    }

    public void CheckForAppliances() {
        // Only do logic if we're not already affecting an appliance
        if (!IsAffectingAppliance) {
            var colliders = Physics.OverlapSphere(gameObject.transform.position, Radius, LayerMask);
            var closestDistance = 0f;
            GameObject closest = null;

            foreach (var c in colliders) {
                float distance = (c.gameObject.transform.position - gameObject.transform.position).magnitude;

                // ignore object if its the previous one we affected
                //if (c.gameObject == previousAppliance) continue;
                // ignore object if its already at its last state
                if (c.gameObject.GetComponent<Appliance>().IsAtMaxState()) continue;

                if (distance > closestDistance) {
                    closestDistance = distance;
                    closest = c.gameObject;
                }
            }

            if (closest != null) {
                agent.destination = closest.transform.position;
                previousAppliance = closest;

                IsAffectingAppliance = true;

                StartCoroutine(AffectAppliance(closest));
            }
        }
    }

    IEnumerator AffectAppliance (GameObject appliance) {
        agent.destination = appliance.transform.position;

        // Wait untill we reached the destination
        while (Vector3.Distance(appliance.transform.position, transform.position) > 1f) {
            yield return null;
        }

        IsAffectingAppliance = false;
        appliance.GetComponent<Appliance>().IncreaseState();

        // Set next destination
        StartCoroutine(GetComponent<EnemyMovement>().NextLocation());
    }
}
