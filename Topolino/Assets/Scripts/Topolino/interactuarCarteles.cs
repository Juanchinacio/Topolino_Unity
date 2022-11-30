using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class interactuarCarteles : MonoBehaviour
{

    public GameObject cartel;
    bool puedoInteracrtuar;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger_Cartel")
        {
            puedoInteracrtuar = true;
            cartel = other.transform.parent.gameObject;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Trigger_Cartel")
        {
            cartel.GetComponent<cartel>().QuitarCartel();
            puedoInteracrtuar = false;
            cartel = null;
        }
    }

    public void OnGrab(InputValue value)
    {
        if (value.isPressed && puedoInteracrtuar)
        {
            cartel.GetComponent<cartel>().mostrarCartel();
        }
    }
}
