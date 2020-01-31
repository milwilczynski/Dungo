using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    private Animator animator;
    public static bool isBlocking;
    public static float delayBetweenAttackAndBlock;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isBlocking = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isBlocking = true;
            animator.SetInteger("block", 1);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            isBlocking = false;
            delayBetweenAttackAndBlock = Time.time + 0.7f;
        }
    }

}
