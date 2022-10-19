using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class InteraccionCajaDeCerillas : MonoBehaviour
{
    public Transform posicionCerillaMano;


    public bool arrastandoObjeto;
    public Transform newPlayerPosition;
    public int playerSpeed = 1;
    public GameObject objectMove;
    public GameObject orientation;
    public bool puedoCogerCerilla = false;
    public bool llevoCerilla = false;
    public bool puedoInteractuarCajaCerilla = false;
    public string cerillaID;
    public GameObject cerilla;
    public GameObject cajaCerilla;

    void Start()
    {

    }

    public void OnRelease(InputValue value)
    {
        if (value.isPressed && llevoCerilla == true)
        {
            SoltarCerilla();
        }
    }

    public void OnGrab(InputValue value)
    {
        if (value.isPressed && puedoCogerCerilla == true)
        {
            CogerCerillaSuelo();
        }
        if (value.isPressed && puedoInteractuarCajaCerilla == true)
        {
            CogerCerillaCaja();
        }
    }



    public void CogerCerillaCaja()
    {
        float step = playerSpeed * Time.deltaTime; // calculate distance to move

        // Posiscion de donde tiene que llevar Topolino la cerrilla
        Vector3 posicionFinalCerilla = posicionCerillaMano.position;
        // Llama al metodo CrearCerilla y paso una referencia a la cerilla creada
        cerillaID = cajaCerilla.GetComponent<CajaCerillas>().CrearCerilla();
        cerilla = GameObject.Find(cerillaID);
        // Emparento la cerilla con Topolino
        cerilla.transform.parent = posicionCerillaMano;
        // La cerrilla creada se tranlada a la mano de topolino
        cerilla.transform.DOMove(posicionFinalCerilla, 1);


        Debug.Log("Creo y recogo cerilla");
    }

    public void CogerCerillaSuelo()
    {
        float step = playerSpeed * Time.deltaTime; // calculate distance to move
        Vector3 posicionFinalCerilla = posicionCerillaMano.position;
        // Emparento la cerilla con Topolino
        cerilla.transform.parent = posicionCerillaMano;
        // La cerrilla creada se tranlada a la mano de topolino
        cerilla.transform.DOMove(posicionFinalCerilla, 1);
    }

    public void SoltarCerilla()
    {

    }

    public void EncenderCerilla()
    {

    }

    IEnumerator ReposicionarJugador(Vector3 _posicionFinal)
    {
        transform.DOMove(_posicionFinal, 1);
        yield return new WaitForSeconds(1);
        objectMove.transform.parent = transform;
    }

    public void SoltarObjeto()
    {
        arrastandoObjeto = false;
        objectMove.transform.parent = null;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger_CajaCerillas")
        {
            cajaCerilla = other.transform.parent.gameObject;
            newPlayerPosition = other.transform.GetChild(0);
            puedoInteractuarCajaCerilla = true;
            Debug.Log("Trigger con la caja de cerillas");
        }
        if (other.gameObject.name == "Trigger_Cerillas")
        {
            cerilla = other.transform.parent.gameObject;
            puedoCogerCerilla = true;
            Debug.Log("Trigger con una cerillas");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Trigger_CajaCerillas")
        {
            puedoInteractuarCajaCerilla = false;
        }
        if (other.gameObject.name == "Trigger_Cerillas")
        {
            puedoCogerCerilla = false;
        }
    }
}
