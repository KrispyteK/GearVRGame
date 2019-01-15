using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour {

    public LayerMask LayerMask;

    public OVRInput.Button ShootButton;
    public KeyCode ShootKey;

    public OVRInput.Button ReloadButton;
    public KeyCode ReloadKey;

    public float damage = 1f;

    private bool aimCharger = false;

    public int maxAmmo = 5;
    private int currentAmmo;
    public int AmmoCost = 100;

    public Camera fpsCam;
    public ParticleSystem Muzzleflash;
    public AudioSource Shootingsound;

    public GameObject AmmoDisplay;
    public GameObject Charger;

    public GameObject ShootEffectPrefab;
    public GameObject ReloadEffectPrefab;

    GameManager GameManager;

    // Update is called once per frame

    private void Start()
    {
        GameManager = GameManager.Instance;
        currentAmmo = maxAmmo;
    }

    void Update () {
        //ChargerCheck();
        if ((OVRInput.GetDown(ShootButton) || Input.GetKeyDown(ShootKey)) && currentAmmo > 0)
        {
                currentAmmo--;
                Muzzleflash.Play();
                Shootingsound.Play();
                Shoot();
        }
        if ((OVRInput.GetDown(ReloadButton) || Input.GetKeyDown(ReloadKey)) && currentAmmo < maxAmmo)
        {
            Reload();
        }

        AmmoDisplay.GetComponent<Text>().text = "" + currentAmmo;

    }
    void Shoot ()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, Mathf.Infinity, LayerMask)){
            Target target = hitInfo.transform.GetComponent<Target>();

            var effect = Instantiate(ShootEffectPrefab);
            var handler = effect.GetComponent<ShootEffectHandler>();

            handler.SetStart(Muzzleflash.transform.position);
            handler.SetEnd(hitInfo.point);

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    void Reload () {
        RaycastHit hitInfo;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, Mathf.Infinity, LayerMask) && hitInfo.transform.tag == "Charger") {
            Charger = hitInfo.transform.gameObject;

            if (Charger != null) {
                currentAmmo = maxAmmo;

                GameManager.Instance.AddEnergyWaste(AmmoCost);

                var effect = Instantiate(ReloadEffectPrefab, Muzzleflash.transform.position, Quaternion.Euler(0,0,0));
                var handler = effect.GetComponent<ShootEffectHandler>();

                handler.SetStart(Muzzleflash.transform.position);
                handler.SetEnd(hitInfo.point);
            }
        }
    }
}
