using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LandingState : StateMachineBehaviour {

    public float Speed = 1f;
    public LayerMask LayerMask;

    private NavMeshAgent agent;
    private Collider collider;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.SetBool("IsWalking", true);

        agent = animator.gameObject.GetComponent<NavMeshAgent>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaycastHit hit;   
        var start = agent.transform.position + Vector3.down * (agent.height * 0.5f - 0.05f);

        if (Physics.Raycast(start, Vector3.down, out hit, Speed * Time.deltaTime, LayerMask)) {
            agent.Warp(hit.point);

            animator.SetBool("HasLanded", true);
        } else {
            agent.transform.position = agent.transform.position + Vector3.down * Speed * Time.deltaTime;
        }
    }  
}
