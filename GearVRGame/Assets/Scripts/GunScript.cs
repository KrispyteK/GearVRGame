using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public float damage = 1f;
    public float range = 100f;

    public Camera fpsCam;
    public ParticleSystem Muzzleflash;
    public AudioSource Shootingsound;
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            Muzzleflash.Play();
            Shootingsound.Play();
            Shoot();
        }
		
	}
    void Shoot ()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range)){
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
