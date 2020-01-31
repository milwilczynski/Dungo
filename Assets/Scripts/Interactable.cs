using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    public Transform interactionTransform;
    Interactable focus;
    bool hasInteracted = false;


    private void Start()
    {
        
    }
    private void Update()
    {
        Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("Interacting with: " + transform.name);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }



}
