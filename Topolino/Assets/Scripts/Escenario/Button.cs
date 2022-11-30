using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public int contador = 0;
    public UnityEvent activaccion;
    public UnityEvent desactivaccion;

    private Animator animaciones;

    private void Start()
    {
        animaciones = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        // Comprobar si pertenece a la LAYER GameObjects
        if (other.gameObject.layer != 7){}

        contador++;
        if (contador == 1)
        {
            // Ejecutar animacion ButtonRelease
            animaciones.Play("Presion");
            // Llamar a evento
            if (activaccion != null)
            {
                Debug.Log("Invoco Evento");
                activaccion.Invoke();
            }
            else
            {
                Debug.Log("No hay evento de activacion asociado");
            }
            //
            Debug.Log("Boton presionado (1 objeto)");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // Comprobar si pertenece a la LAYER GameObjects
        if (other.gameObject.layer != 7) { }

        contador--;
        if (contador == 0)
        {
            // Ejecutar animacion ButtonRealease
            animaciones.Play("DesPresion");
            // Desactivar evento
            if (activaccion != null)
            {
                desactivaccion.Invoke();
            }
            else
            {
                Debug.Log("No hay evento de desactivacion asociado");
            }
            //
            Debug.Log("Boton NO presionado (0 objeto)");
        }
    }
}
