using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIncreasingState : MonoBehaviour {

    public Vector3 position;
    public int radius = 100;
    public bool go = false;
    private float speed = 3.5f;

    private void Start()
    {
        position = gameObject.transform.position;
        checkForAppliance();
    }

    public void checkForAppliance()
    {
        var colliders = Physics.OverlapSphere(position, radius, LayerMask.NameToLayer("Appliance"));
        var closestDistance = 0f;
        GameObject closest = null;

        foreach (var c in colliders)
        {

            float distance = (c.gameObject.transform.position - position).magnitude;
            Debug.Log(distance);
            if (distance > closestDistance)
            {
                closestDistance = distance;
                closest = c.gameObject;
                Debug.Log("found "+ c.gameObject.name);
            }
        }


        if (closest != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, closest.transform.position, speed * Time.deltaTime);
            Debug.Log("changed");
            go = true;
            closest.GetComponent<Appliance>().IncreaseState();
        }
    }

}
