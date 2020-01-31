using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Animator playerAnimator;
    public CharacterStats myStats;
    private float delayTimeHitBox = 1.3f;
    private float timeHolder;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

    }


    void OnTriggerEnter(Collider col)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack02") == true && Time.time > timeHolder)
        {
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Block") == false)
            {
                Debug.Log(col.transform.name);
                if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
                {
                    Debug.Log(col.tag);
                    GameObject.FindWithTag("Player").GetComponent<CharacterStats>().TakeDamage(20);
                    //col.transform.GetComponent<CharacterStats>().TakeDamage(myStats.damage.GetValue());
                    timeHolder = Time.time + delayTimeHitBox;
                }
            }
        }
    }
}

