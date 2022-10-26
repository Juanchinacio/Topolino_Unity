using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agua : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cerilla")
        {
            other.GetComponent<Cerilla>().Apagar();
        }
    }
}
