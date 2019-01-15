using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 5f;
    public static bool isGrounded = false;

    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health < 1)
        {
            Die();
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

}
