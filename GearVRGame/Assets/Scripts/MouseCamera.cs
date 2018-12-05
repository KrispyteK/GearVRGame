using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour {

    public float Sensitivity;
    public Transform Parent;

	void Start () {
		
	}

	void Update () {
        transform.Rotate(transform.right, Input.GetAxis("Vertical"));
        Parent.Rotate(Vector3.up, Input.GetAxis("Horizontal"));
	}
}
