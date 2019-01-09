using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIIncreasingState : MonoBehaviour {

    public Vector3 position;
    public int radius = 10;

    private void Start()
    {
        position = gameObject.transform.position;
    }
    
    public void checkForAppliance()
    {
        var colliders = Physics.OverlapSphere(position, radius, LayerMask.NameToLayer("Appliance"));
        var closestDistance = 0f;
        GameObject closest = null;
        {
            /*var distance = (c.gameObject.transform.position - position).Magnitude;

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = c.gameObject;
            }*/
        }

        if (closest != null)
        {
            closest.GetComponent<Appliance>().IncreaseState();
        }
    }

}
