using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remote : MonoBehaviour {

    public GameObject Gun;
    public Transform CameraAnchor;
    public Transform RemoteAnchor;

    public Transform CameraGunParent;
    public Transform RemoteGunParent;

    public bool pointerIsRemote;

    private GunScript gunScript;
    private PlayerInteract playerInteract;
    private TeleportController teleportController;

    void Start () {
        gunScript = Gun.GetComponent<GunScript>();
        playerInteract = GetComponent<PlayerInteract>();
        teleportController = GetComponent<TeleportController>();
    }

    private void Update()
    {
        Gun.transform.SetParent(GunTransform);
        Gun.transform.localPosition = Vector3.zero;
        Gun.transform.localRotation = Quaternion.Euler(0, 0, 0);
        
    }

    public Transform Pointer
    {
        get
        {
            OVRInput.Controller controller = OVRInput.GetConnectedControllers();
            pointerIsRemote = true;
            if ((controller & OVRInput.Controller.RTrackedRemote) != OVRInput.Controller.None)
            {           
                return RemoteAnchor;
            }
            // If no controllers are connected, we use ray from the view camera. 
            // This looks super ackward! Should probably fall back to a simple reticle!
            pointerIsRemote = false;

            return CameraAnchor;
        }
    }

    public Transform GunTransform
    {
        get
        {
            OVRInput.Controller controller = OVRInput.GetConnectedControllers();
            if ((controller & OVRInput.Controller.RTrackedRemote) != OVRInput.Controller.None)
            {
                return RemoteGunParent;
            }
            return CameraGunParent;
        }
    }
}
