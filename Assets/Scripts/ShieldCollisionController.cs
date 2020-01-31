using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollisionController : MonoBehaviour
{
    public Collider playerCollider;
    public BoxCollider shieldCollider;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(playerCollider, GetComponent<Collider>(), true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!BlockControl.isBlocking)
        {
            shieldCollider.enabled = false;
        }
        else
        {
            shieldCollider.enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        animator.SetInteger("impact", 1);
        //collision.gameObject.transform.position = Vector3.Reflect(collision.gameObject.transform.position, Vector3.left);
    }
    private void OnTriggerEnter(Collider col)
    {
        animator.SetInteger("impact", 1);
    }
}
