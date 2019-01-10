using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaitState : StateMachineBehaviour
{

    private float startTime;
    private float waitTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsWaiting", true);

        waitTime = Random.Range(1f,2f);

        startTime = Time.time;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if ((Time.time - startTime) > waitTime)
        {
            animator.SetBool("IsWaiting", false);
        }
    }
}