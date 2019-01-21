using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaitState : StateMachineBehaviour
{

    public float MinWaitTime = 2f;
    public float MaxWaitTime = 4f;

    private float startTime;
    private float waitTime;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsWaiting", true);

        waitTime = Random.Range(MinWaitTime, MaxWaitTime);

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