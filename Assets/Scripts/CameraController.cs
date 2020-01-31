using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 6;
    public Transform target;
    public float dstFromTarget = 6.0f;
    public Vector2 pitchMinMax = new Vector2(-5, 85);
    public LayerMask layer;

    public float rotationSmoothTime = 10.0f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;

    private float yaw;
    private float pitch;
    private float saveDst;
    private bool cameraColision;
    private bool cameraCanTurnBack;

    //Colision
    public bool collisionDebug;
    public float collisionOffSet = 0.35f;
    Ray camRay;
    RaycastHit camRayHit;

    private void Start()
    {
        saveDst = dstFromTarget;
    }
    void LateUpdate()
    {
        CameraCollision();
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
        transform.eulerAngles = currentRotation;
        transform.position = target.position - (transform.forward * dstFromTarget);
    }

    void CameraCollision()
    {
        float camDistance = Vector3.Distance(transform.position, target.transform.position) + collisionOffSet;
        camRay.origin = transform.position;
        camRay.direction = target.transform.position - Camera.main.transform.position;

        if (Physics.Raycast(camRay, out camRayHit, camDistance, layer))
        {
            dstFromTarget = Vector3.Distance(camRay.origin, camRayHit.point);
        }
        else
        {
            if (dstFromTarget < saveDst)
            {
                dstFromTarget = Vector3.Distance(transform.position, target.transform.position);
            }
        }

        //Debug.DrawLine(camRay.origin, camRay.origin + camRay.direction * Vector3.Distance(transform.position, target.transform.position), Color.green);
    }
}