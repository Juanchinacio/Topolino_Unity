using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diente : MonoBehaviour
{
    public tiemposNiveles tiemposNiveles;

    private void Start()
    {
        tiemposNiveles = GameObject.Find("Controlador Tiempo").GetComponent<tiemposNiveles>();
    }
    void OnTriggerEnter(Collider other)
    {
        tiemposNiveles.GuardarTiempo();
        GameManager.manager.LoadScene(0);
    }
}
