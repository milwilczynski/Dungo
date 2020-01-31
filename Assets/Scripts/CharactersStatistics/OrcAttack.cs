using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public Animator playerAnimator; 
    public CharacterStats myStats;
    private bool triggered = false;
    private float delayTimeHitBox = 1f;
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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack01") == true && Time.time > timeHolder)
        {
            if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Block") == false && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("ShieldImp") == false)
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
            else if(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Block") == true)
            {
                playerAnimator.SetInteger("impact", 1);
            }
        }
    }
}
