using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody rb;
    public Transform lockerTransform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lockerTransform = GameObject.Find("Locker").transform;
        transform.LookAt(lockerTransform);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.TransformDirection(Vector3.forward * 10);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(collision.transform.name == "Player")
            {
                collision.transform.GetComponent<CharacterStats>().TakeDamage(20);
                Destroy(gameObject);
            }
            Debug.Log(collision.transform.name);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }
}
