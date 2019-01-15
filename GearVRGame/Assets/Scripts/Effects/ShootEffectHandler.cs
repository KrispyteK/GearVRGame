using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEffectHandler : MonoBehaviour {

    public float Time = 1f;
    public GameObject particles;
    public LineRenderer line;

    public void SetStart (Vector3 v) {
        line.SetPosition(0, v);

        StartCoroutine(DestroyDelay());
    }

    public void SetEnd(Vector3 v) {
        line.SetPosition(1, v);
        particles.transform.position = v;
    }

    IEnumerator DestroyDelay () {
        yield return new WaitForSeconds(Time);

        Destroy(gameObject);
    }
}
