using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulletSpawner : MonoBehaviour
{
    public GameObject prefab;
    private float timeToWait=0.5f;
    public static bool shootFired;
    void Start()
    {
    }

    
    void Update()
    {
        if(ShootOnExit.shootLich && shootFired)
        {
            Instantiate(prefab, transform.position, transform.rotation);
            ShootOnExit.delay = Time.time + timeToWait;
            shootFired = false;
        }
    }
    
  
}
