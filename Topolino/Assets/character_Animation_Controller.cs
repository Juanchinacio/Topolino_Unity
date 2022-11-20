using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class character_Animation_Controller : MonoBehaviour
{
    public Animator character_Animator;

    public float velocidadX;

    public string nombrePersonaje;
    public string[] nombreAnimaciones;

    public bool moviendo;

    public Grounded ground;

    Rigidbody rb;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        //EjecutarAnimacion(11);
        //character_Animator = transform.GetChild(4).GetComponent<Animator>();
    }

    private void Update()
    {
        if (ground.onGround == false)
        {
            //EjecutarAnimacion(9);
            if (rb.velocity.y > 0)
            {
                EjecutarAnimacion(9);
            }
            else
            {
                EjecutarAnimacion(10);
            }
        }
        else if (ground.onGround == true)
        {
            //EjecutarAnimacion(0);
            if (moviendo)
            {
                EjecutarAnimacion(3);
            
            }
            else
            {
                EjecutarAnimacion(0);
            }
        }
        //else
        //{
        //    EjecutarAnimacion(3);
        //}
    
    
    }

    //public void OnMovement(InputValue value)
    //{
    //    moviendo = true;
    //    if (value.isPressed)
    //    {
    //        moviendo = true;
    //    }
    //    else
    //    {
    //        moviendo = false;
    //    }        
    //}



    public void EjecutarAnimacion(int _idxAnimacion)
    {
        if (_idxAnimacion <= nombreAnimaciones.Length)
        {
            string aux = nombrePersonaje + "_" + nombreAnimaciones[_idxAnimacion];
            character_Animator.Play(aux);
            Debug.Log("Animación " + aux + " ejecutada");
        }
        else
        {
            Debug.Log("Indice de animacion ecxedido");
        }
        
    }
}
