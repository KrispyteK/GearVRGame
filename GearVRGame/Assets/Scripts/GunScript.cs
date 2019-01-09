using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {

    public float damage = 1f;
    public float range = 100f;

    public int maxAmmo = 10;
    private int currentAmmo;
    private int AmmoCost = 100;
    public float reloadTime = 1f;

    public Camera fpsCam;
    public ParticleSystem Muzzleflash;
    public AudioSource Shootingsound;

    public GameObject AmmoDisplay;
    GameManager GameManager;

    // Update is called once per frame

    private void Start()
    {
        GameManager = GameManager.Instance;
        currentAmmo = maxAmmo;
    }

    void Update () {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0)
        {
                currentAmmo--;
                Muzzleflash.Play();
                Shootingsound.Play();
                Shoot();
        }
        if (Input.GetButtonDown("Fire4") && currentAmmo < maxAmmo)
        {
            currentAmmo = maxAmmo;
            GameManager.EnergyWastage += AmmoCost;
        }

        AmmoDisplay.GetComponent<Text>().text = "" + currentAmmo;

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
