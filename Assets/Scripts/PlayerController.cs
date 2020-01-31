using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool inCombat = false;
    public float runSpeed = 2;
    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;
    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    Transform cameraT;
    Animator animator;

    public static bool isAttacking = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        cameraT = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!BlockControl.isBlocking && !isAttacking) {
            movement();
            attack();
        }
    }
    private void movement()
    {
        if (!CharacterStats.deadPlayed)
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 inputDir = input.normalized;

            if (inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }

            float speed = runSpeed * inputDir.magnitude;
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);
            animator.SetFloat("speedPercent", speed, (speed == 0) ? 0.1f : 1, Time.deltaTime);
        } 
    }
    private void attack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking && (Time.time > BlockControl.delayBetweenAttackAndBlock))
        {
            isAttacking = true;
            animator.SetInteger("attack", 1);

         
        }
    }
}
