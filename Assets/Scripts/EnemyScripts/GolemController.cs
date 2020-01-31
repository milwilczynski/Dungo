using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GolemController : MonoBehaviour
{
    public float lookRadius = 10;
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    const float locomotionAnimationSmoothTime = .1f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;
        animator = GetComponent<Animator>();
        animator.SetFloat("speedPercent", 0);
    }

    // Update is called once per frame
    void Update()
    {
        //load ditance into variable - if distance is lower than lookRadius then for e.g chase player
        //else TargetGone() update speedPercent variable via Movement() method.
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {

            //if attack01 animation is not launched Movement() in player direction
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack01") == false)
            {
                Movement();
                agent.SetDestination(target.position);
            }

            //id distance is lower than opponent stopping distance then FaceTarget()
            if (distance <= agent.stoppingDistance)
            {
                //attack
                //face
                FaceTarget();
            }
            else
            {
                animator.SetInteger("attack", 0);
            }

        }
        else
        {
            TargetGone();
            Movement();
        }
    }

    //Attack player and rotate opponent to be faced to face to player
    void FaceTarget()
    {

        animator.SetInteger("attack", 2);
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    //Detect Radius Color Setter
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    //Do something if player disappears from detect radius
    void TargetGone()
    {
        animator.SetInteger("attack", 0);
    }

    //Opponent movement
    void Movement()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
    }
}
