using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class interactuarPalanca : MonoBehaviour
{
    public bool puedointeractuar = false;
    public GameObject palanca;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger_Palanca")
        {
            puedointeractuar = true;
            palanca = other.transform.parent.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Trigger_Palanca")
        {
            puedointeractuar = false;
            palanca = null;
        }
    }

    public void OnGrab(InputValue value)
    {
        if (value.isPressed && puedointeractuar == true)
        {
            palanca.GetComponent<palanca>().Interactuar();
        }
    }
}
