 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PickObject : MonoBehaviour
{
    public Collider objetoCogido;

    public int contadorObjetos = 0;

    public GameObject top_Object;
    public GameObject front_Object;

    Transform top_Object_Position;
    Transform front_Object_Position;

    public List<Collider> Objetos;

    public bool llevandoObjeto = false;

    bool pickKeyDown;

    public KeyCode pickKey = KeyCode.E;

    private void Start()
    {
        top_Object_Position = top_Object.transform;
        front_Object_Position = front_Object.transform;
    }

    public void OnGrab(InputValue value)
    {
        //Debug.Log("GRABBBBBBBBBBBBBBBBBBB");
        //Debug.Log("QUE PASAAAAAAAAAAAAAAAAAA");
        if (value.isPressed && contadorObjetos > 0 && llevandoObjeto == false)
        {
            CogerObjeto();
        }
        if (value.isPressed == false && llevandoObjeto == true)
        {
            SoltarObjeto();
        }
    }

    void Update()
    {
        //Debug.Log("Cantidad de objetos: " + Objetos.Count + " Tecla E presionada: " + Input.GetKey(pickKey));
        //int cantidadObjetos = Objetos.Count;
        ////bool presionandoTeclaE = Input.GetKeyDown(pickKey);
        //
        //
        //if (contadorObjetos > 0 && Input.GetKeyDown(pickKey) && llevandoObjeto == false)
        //{
        //    //Debug.Log("K onda");
        //    CogerObjeto();
        //}
        //else if (Input.GetKeyDown(pickKey) && llevandoObjeto == true)
        //{
        //    SoltarObjeto();
        //}
    }

    public void SoltarObjeto()
    {
        llevandoObjeto = false;

        // Quitar dependencia del jugador
        objetoCogido.transform.parent = null;

        // Desactivar fisicas del objeto cogido
        objetoCogido.transform.GetComponent<Rigidbody>().isKinematic = false;
        this.GetComponent<SpringJoint>().connectedBody = null;

    }

    public void CogerObjeto()
    {
        Debug.Log("Coger objeto");

        Vector3 posicionFinal_Top = top_Object_Position.position;
        Vector3 rotacionFinal_Top = top_Object_Position.eulerAngles;
        Vector3 posicionFinal_Front = front_Object_Position.position;
        Vector3 rotacionFinal_Front = front_Object_Position.eulerAngles;

        llevandoObjeto = true;

        objetoCogido = Objetos[0];
        //objetoCogido = Objetos[0].transform.gameObject;

        if (objetoCogido.gameObject.CompareTag("Object(Top)") || objetoCogido.gameObject.CompareTag("Object(Front)"))
        {
            // Desactivar fisicas del objeto cogido
            objetoCogido.transform.GetComponent<Rigidbody>().isKinematic = true;
            // Hacer al objeto hijo del "jugador"
            objetoCogido.transform.parent = top_Object.transform;
        }
        
        // Dependiedo del tag, el objeto es cogido arriba o enfrente
        if (objetoCogido.gameObject.CompareTag("Object(Top)"))
        {
            objetoCogido.transform.DOMove(posicionFinal_Top, 1);
            objetoCogido.transform.DORotate(rotacionFinal_Top, 1);
        }
        if (objetoCogido.gameObject.CompareTag("Object(Front)"))
        {
            objetoCogido.transform.DOMove(posicionFinal_Front, 1);
            objetoCogido.transform.DORotate(rotacionFinal_Front, 1);
        }
        if (objetoCogido.gameObject.CompareTag("Object(Physics)"))
        {
            objetoCogido.transform.DOMove(posicionFinal_Front, 1);
            objetoCogido.transform.DORotate(rotacionFinal_Front, 1);
            //this.GetComponent<SpringJoint>().connectedBody = objetoCogido.gameObject.GetComponent<Rigidbody>();
            this.GetComponent<SpringJoint>().connectedBody = objetoCogido.gameObject.GetComponent<Rigidbody>();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object(Top)") || other.gameObject.CompareTag("Object(Front)") || other.gameObject.CompareTag("Object(Physics)"))
        {
            contadorObjetos--;
            Objetos.Remove(other);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object(Top)") || other.gameObject.CompareTag("Object(Front)") || other.gameObject.CompareTag("Object(Physics)"))
        {
            contadorObjetos++;
            Objetos.Add(other);
        }
    }
}
