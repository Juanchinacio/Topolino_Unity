using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    GameObject camera;

    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }
    void Update()
    {
        transform.LookAt(camera.transform);
    }
}
