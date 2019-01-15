using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {

    public OVRInput.Button ShootButton;
    public KeyCode ShootKey;

    public OVRInput.Button ReloadButton;
    public KeyCode ReloadKey;

    public float damage = 1f;

    private bool aimCharger = false;

    public int maxAmmo = 5;
    private int currentAmmo;
    private int AmmoCost = 100;

    public Camera fpsCam;
    public ParticleSystem Muzzleflash;
    public AudioSource Shootingsound;

    public GameObject AmmoDisplay;
    public GameObject Charger;
    GameManager GameManager;

    // Update is called once per frame

    private void Start()
    {
        GameManager = GameManager.Instance;
        currentAmmo = maxAmmo;
    }

    void Update () {
        ChargerCheck();
        if ((OVRInput.GetDown(ShootButton) || Input.GetKeyDown(ShootKey)) && currentAmmo > 0)
        {
                currentAmmo--;
                Muzzleflash.Play();
                Shootingsound.Play();
                Shoot();
        }
        if ((OVRInput.GetDown(ReloadButton) || Input.GetKeyDown(ReloadKey)) && currentAmmo < maxAmmo && aimCharger)
        {
            currentAmmo = maxAmmo;

            GameManager.Instance.AddEnergyWaste(AmmoCost);
        }

        AmmoDisplay.GetComponent<Text>().text = "" + currentAmmo;

    }
    void Shoot ()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo)){
            Target target = hitInfo.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    void ChargerCheck()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo) && hitInfo.transform.tag == "Charger")
        {
            Charger = hitInfo.transform.gameObject;
            if (Charger != null)
            {
                aimCharger = true;
            }
        }
    }
}
