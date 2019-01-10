using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIComponent : MonoBehaviour {

    public LayerMask LayerMask;
    public float Cooldown = 4f;
    public float LookRadius = 4f;
    public GameObject TargetAppliance;
    public List<GameObject> PreviousAppliances = new List<GameObject>();

    private Animator animator;
    private RuntimeAnimatorController controller;

	void Start () {
        animator = GetComponent<Animator>();
        controller = animator.runtimeAnimatorController;
    }

	void Update () {
        CheckForAppliances();

        animator.SetBool("IsSeeingAppliance", TargetAppliance != null);
    }

    public void CheckForAppliances()
    {
        var colliders = Physics.OverlapSphere(gameObject.transform.position, LookRadius, LayerMask);
        var closestDistance = 0f;
        TargetAppliance = null;

        foreach (var c in colliders)
        {
            float distance = (c.gameObject.transform.position - gameObject.transform.position).magnitude;

            // ignore object if its the previous one we affected
            if (PreviousAppliances.Contains(c.gameObject)) continue;
            // ignore object if its already at its last state
            if (c.gameObject.GetComponent<Appliance>().IsAtMaxState()) continue;

            if (distance > closestDistance)
            {
                closestDistance = distance;
                TargetAppliance = c.gameObject;
            }
        }
    }

    public void StartCoolDown (GameObject appliance)
    {
        PreviousAppliances.Add(appliance);

        StartCoroutine(ApplianceCooldown(appliance));
    }

    IEnumerator ApplianceCooldown (GameObject appliance)
    {
        yield return new WaitForSeconds(Cooldown);

        PreviousAppliances.Remove(appliance);
    }

}
