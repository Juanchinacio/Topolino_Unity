using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuego : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cerilla")
        {
            other.GetComponent<Cerilla>().Encender();
        }
    }
}
