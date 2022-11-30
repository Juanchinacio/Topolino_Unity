using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraDirection : MonoBehaviour
{
    //public GameObject direction;
    public Transform cameraTransform;
    public float smootTime = 0.1f;
    public float turnSmoothTime = 0.1f;
    float speedSmoothVelocity;

    void Start()
    {
        //cameraTransform = Camera.main.transform;
    }
    void Update()
    {
        float targetRotation = cameraTransform.eulerAngles.y;
        transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref speedSmoothVelocity, turnSmoothTime);
    }
}
