using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public Transform PointerTransform;
    public float MaxInteractRange = 3f;
    public OVRInput.Button InteractButton;
    public KeyCode InteractKey;

    void Update () {
        if (OVRInput.GetDown(InteractButton) || Input.GetKeyDown(InteractKey)) {
            RaycastHit hit;

            if (Physics.Raycast(PointerTransform.position, PointerTransform.forward, out hit, MaxInteractRange)) {
                var interactable = hit.collider.gameObject.GetComponent<IInteractable>();

                if (interactable != null) {
                    interactable.OnInteract();
                }              
            }
        }
    }
}
