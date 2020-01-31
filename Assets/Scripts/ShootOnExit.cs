using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootOnExit : StateMachineBehaviour
{
    public static bool shootLich = false;
    public static bool shootFired = true;
    public static float delay = 0.0f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //        
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float animationIndex = ((stateInfo.normalizedTime * (stateInfo.length))) % stateInfo.length;
        if(shootFired && Time.time > delay)
        {
            shootLich = false;
            TestBulletSpawner.shootFired = true;
        }
        if(animationIndex > 1.05 && !shootLich)
        {
            shootLich = true;
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        // Implement code that processes and affects root motion
    //    Debug.Log("asdb");
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        // Implement code that sets up animation IK (inverse kinematics)
    //    Debug.Log("asdc");
    //}
}
