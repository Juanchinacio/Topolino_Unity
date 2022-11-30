using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class antorchas : MonoBehaviour
{
    public GameObject fuego;
    public UnityEvent activaccion;


    private void Start()
    {
        fuego.SetActive(false);
    }

    public void Quemar()
    {
        fuego.SetActive(true);
        activaccion.Invoke();
    }
}
