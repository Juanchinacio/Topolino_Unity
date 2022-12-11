using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class percepcion_TopolinoCerca : MonoBehaviour
{
    [SerializeField] UnityEvent _topolinoCerca;
    [SerializeField] UnityEvent _topolinoNoCerca;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _topolinoCerca.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _topolinoNoCerca.Invoke();
        }
    }
}
