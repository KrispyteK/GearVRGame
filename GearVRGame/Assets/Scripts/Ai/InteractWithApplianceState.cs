using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InteractWithApplianceState : StateMachineBehaviour
{
    #region Private Variables
    private NavMeshAgent agent;
    private GameObject appliance;
    private bool hasInteracted = false;
    #endregion

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasInteracted = false;

        agent = animator.gameObject.GetComponent<NavMeshAgent>();

        appliance = animator.gameObject.GetComponent<AIComponent>().TargetAppliance;

        animator.SetBool("IsInteractingWithAppliance", true);

        agent.destination = appliance.gameObject.transform.position;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (agent.remainingDistance == 0 && !hasInteracted) {
            appliance.GetComponent<Appliance>().IncreaseState();

            animator.gameObject.GetComponent<AIComponent>().StartCoolDown(appliance);

            animator.SetBool("IsInteractingWithAppliance", false);

            hasInteracted = true;
        }
    }
}