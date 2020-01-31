using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.AI;
public class EnemyStats : CharacterStats
{
    Animator animator;

    public float bodyDisappear = 8.0f;
    private float bodyDisappearTimeHolder;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (animator.GetBool("dead"))
        {
            if(Time.time >= bodyDisappearTimeHolder)
            {
                Destroy(gameObject);
            }
        }
    }
    public override void Die()
    {
        base.Die();
        animator.SetBool("attack", false);
        animator.SetBool("dead", true);
        bodyDisappearTimeHolder = Time.time + bodyDisappear;
        this.GetComponent<CapsuleCollider>().enabled = false; // Zeby mozna bylo przechodzic po smierci
        this.GetComponent<NavMeshAgent>().enabled = false; // Zeby mozna bylo przechodzic po smierci

        //Destroy(gameObject);
    }
}
