using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public Collider[] swordHitbox;
    public Animator animator;
    public CharacterStats myStats;
    public Collision collision;
    private bool triggered = false;
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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack") == true && triggered == false && Time.time > timeHolder)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Hitbox"))
            {
                col.transform.GetComponent<CharacterStats>().TakeDamage(myStats.damage.GetValue());
                triggered = true;
                timeHolder = Time.time + delayTimeHitBox;
            }
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("SwordAttack") == true && triggered == true)
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Hitbox"))
            {
                triggered = false;
            }
        }
    }


    //method to be used in update, it works multiple times tho
    private void SwordAttack(Collider col)
    {
        Collider[] cols = Physics.OverlapBox(col.bounds.center, col.bounds.extents, col.transform.rotation, LayerMask.GetMask("Hitbox"));
        foreach(Collider c in cols)
        {
            if (c.transform.parent == transform)
                continue;

            c.GetComponent<CharacterStats>().TakeDamage(5);
  
        }
    }
}
