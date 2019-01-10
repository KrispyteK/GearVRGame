using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkState : StateMachineBehaviour
{
    public float WalkRadius = 5f;
    #region Private Variables
    private NavMeshAgent agent;
    #endregion

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsWalking", true);

        agent = animator.gameObject.GetComponent<NavMeshAgent>();

        Vector3 randomDirection = Random.insideUnitSphere * WalkRadius;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, WalkRadius, 1);
        Vector3 finalPosition = hit.position;

        agent.destination = finalPosition;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance == 0)
        {
            animator.SetBool("IsWalking", false);
        }
    }
}