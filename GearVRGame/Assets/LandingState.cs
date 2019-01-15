using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingState : StateMachineBehaviour {

    public float smooth = 1f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsLanding", true);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
    
        if (Target.isGrounded)
        {
            animator.SetBool("IsLanding", false);

        }

    }
    
}
