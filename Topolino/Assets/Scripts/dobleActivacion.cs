using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class dobleActivacion : MonoBehaviour
{
    public int cantidadNecesaria;
    public int cantidadActual;

    public UnityEvent activaccion;
    public UnityEvent desactivaccion;

    public void Mas()
    {
        cantidadActual++;
        Comprobar();
    }
    public void Menos()
    {
        cantidadActual--;
        Comprobar();
    }

    public void Comprobar()
    {
        if (cantidadActual == cantidadNecesaria)
        {
            Evento_Desactivación();
        }
        else
        {
            Evento_Activación();

        }
    }

    public void Evento_Activación()
    {
        activaccion.Invoke();
    }

    public void Evento_Desactivación()
    {
        desactivaccion.Invoke();
    }
}
