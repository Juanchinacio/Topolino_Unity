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
        if (other.gameObject.tag == "Telaranya")
        {
            Debug.Log("QUEMAR TELARANYA");
            other.GetComponent<telaranya>().Quemar();
        }
        if (other.gameObject.tag == "Antorcha")
        {
            Debug.Log("QUEMAR TELARANYA");
            other.GetComponent<antorchas>().Quemar();
        }
    }
}
