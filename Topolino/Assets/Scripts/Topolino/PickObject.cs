 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PickObject : MonoBehaviour
{
    public Collider objetoCogido;
    public bool reposicionando = false;
    public int contadorObjetos = 0;
    public GameObject top_Object;
    public GameObject front_Object;
    Transform top_Object_Transform;
    Transform front_Object_Transform;


    public List<Collider> Objetos;
    public bool llevandoObjeto = false;

    [Header("Animator")]
    public Animator _animator;
    private int _idHold;

    [SerializeField]
    public AudioSource grab;
    public AudioSource drop;


    private void Start()
    {
        _idHold = Animator.StringToHash("isHolding");

        top_Object_Transform = top_Object.transform;
        front_Object_Transform = front_Object.transform;
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
    }

    public void SoltarObjeto()
    {
        _animator.SetBool(_idHold, false);
        GameManager.manager.PlayAudio(drop, Audio.sound);

        llevandoObjeto = false;
        reposicionando = false;
        // Quitar dependencia del jugador
        objetoCogido.transform.parent = null;

        // Desactivar fisicas del objeto cogido
        objetoCogido.transform.GetComponent<Rigidbody>().isKinematic = false;
        //this.GetComponent<SpringJoint>().connectedBody = null;

    }

    public void CogerObjeto()
    {
        _animator.SetBool(_idHold, true);

        Debug.Log("Coger objeto");

        GameManager.manager.PlayAudio(grab, Audio.sound);

        llevandoObjeto = true;

        objetoCogido = Objetos[0];
        //objetoCogido = Objetos[0].transform.gameObject;

        if (objetoCogido.gameObject.CompareTag("Object(Top)") || objetoCogido.gameObject.CompareTag("Object(Front)"))
        {
            reposicionando = true;
            // Desactivar fisicas del objeto cogido
            objetoCogido.transform.GetComponent<Rigidbody>().isKinematic = true;
            // Hacer al objeto hijo del "jugador"
            objetoCogido.transform.parent = top_Object.transform;
        }
        
        // Dependiedo del tag, el objeto es cogido arriba o enfrente
        if (objetoCogido.gameObject.CompareTag("Object(Top)"))
        {
            objetoCogido.transform.position = top_Object_Transform.position;
            objetoCogido.transform.rotation = top_Object_Transform.rotation;
        }
        if (objetoCogido.gameObject.CompareTag("Object(Front)"))
        {
            objetoCogido.transform.position = front_Object_Transform.position;
            objetoCogido.transform.rotation = front_Object_Transform.rotation;

        }
        if (objetoCogido.gameObject.CompareTag("Object(Physics)"))
        {
            objetoCogido.transform.position = front_Object_Transform.position;
            objetoCogido.transform.rotation = front_Object_Transform.rotation;

            ////this.GetComponent<SpringJoint>().connectedBody = objetoCogido.gameObject.GetComponent<Rigidbody>();
            this.GetComponent<SpringJoint>().connectedBody = objetoCogido.gameObject.GetComponent<Rigidbody>();
        }

    }
}
