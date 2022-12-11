using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class percepcion_VeTopolino : MonoBehaviour
{
    [SerializeField] UnityEvent topolinoVisto;
    [SerializeField] UnityEvent topolinoNoVisto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            topolinoVisto.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            topolinoNoVisto.Invoke();
        }
    }
}
