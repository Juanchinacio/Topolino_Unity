using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<PlayerMovement>().grounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
            GetComponentInParent<PlayerMovement>().grounded = false;
    }
}
