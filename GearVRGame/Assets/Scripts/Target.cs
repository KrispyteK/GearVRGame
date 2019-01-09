using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 5f;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health < 1)
        {
            Progress.progress++;
            Die();
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }

}
