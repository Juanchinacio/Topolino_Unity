using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class palanca : MonoBehaviour
{
    public bool activado = false;
    public UnityEvent activaccion;
    public UnityEvent desactivaccion;

    Animator animaciones;

    private void Start()
    {
        animaciones = GetComponent<Animator>();
        if (activado)
        {
            animaciones.Play("Activar");
        }
        else
        {
            animaciones.Play("Desactivar");
        }
    }

    public void Interactuar()
    {
        if (!activado)
        {
            ActivarPalanca();
        }
        else if (activado)
        {
            DesactivarPalanca();
        }
    }

    void ActivarPalanca()
    {
        Debug.Log("Activo palanca");
        animaciones.Play("Activar");
        activado = true;
        activaccion.Invoke();
    }

    void DesactivarPalanca()
    {
        Debug.Log("Desactivo palanca");
        animaciones.Play("Desactivar");
        activado = false;
        desactivaccion.Invoke();
    }
}
