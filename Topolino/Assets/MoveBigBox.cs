using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class MoveBigBox : MonoBehaviour
{
    public bool arrastandoObjeto;
    enum Direction { Left, Right, Top, Bottom, None};
    Direction myDirection = Direction.None;
    public Transform newPlayerPosition;
    public int playerSpeed = 1;
    public GameObject objectMove;
    public GameObject orientation;
    public bool objetoInteractuable = false;

    void Start()
    {
        
    }

    public void OnGrab(InputValue value)
    {
        //Debug.Log("QUE PASAAAAAAAAAAAAAAAAAA");
        if (value.isPressed && arrastandoObjeto == false && objetoInteractuable == true)
        {
            ArrastarObjeto();
        }
        if (value.isPressed == false && arrastandoObjeto == true)
        {
            SoltarObjeto();
        }
    }

    public void ArrastarObjeto()
    {
        arrastandoObjeto = true;

        float step = playerSpeed * Time.deltaTime; // calculate distance to move
                                                   //newPlayerPosition = new Vector3(newPlayerPosition.position.x, transform.position.y, newPlayerPosition.position.z);
        Vector3 posicionFinal = new Vector3(newPlayerPosition.position.x, transform.position.y, newPlayerPosition.position.z);

        //transform.DOMove(posicionFinal, 1);
        ////transform.DOMove(posicionFinal, 1);
        ////objectMove.transform.parent = transform;
        StartCoroutine(ReposicionarJugador(posicionFinal));

        // La caja es hijo de topolino


        // Bloqueo el movimiento en los ejes que me interesa
        if (myDirection == Direction.Top || myDirection == Direction.Bottom)
        {
            GetComponent<Player_Movement>().move_X_Block = true;
        }
        else if (myDirection == Direction.Left || myDirection == Direction.Right)
        {
            GetComponent<Player_Movement>().move_Z_Block = true;
        }

        

        Debug.Log("Recolocando jugador");

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
        // Quitar restricciones de movimiento de Topolino
        GetComponent<Player_Movement>().move_Z_Block = false;
        GetComponent<Player_Movement>().move_X_Block = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger_R")
        {
            myDirection = Direction.Right;
            newPlayerPosition = other.transform.GetChild(0);
            objectMove = other.transform.parent.gameObject;
            objetoInteractuable = true;
        }
        if (other.gameObject.name == "Trigger_L")
        {
            myDirection = Direction.Left;
            newPlayerPosition = other.transform.GetChild(0);
            objectMove = other.transform.parent.gameObject;
            objetoInteractuable = true;
        }
        if (other.gameObject.name == "Trigger_T")
        {
            myDirection = Direction.Top;
            newPlayerPosition = other.transform.GetChild(0);
            objectMove = other.transform.parent.gameObject;
            objetoInteractuable = true;
        }
        if (other.gameObject.name == "Trigger_B")
        {
            myDirection = Direction.Bottom;
            newPlayerPosition = other.transform.GetChild(0);
            objectMove = other.transform.parent.gameObject;
            objetoInteractuable = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Trigger_B" || other.gameObject.name == "Trigger_T" || other.gameObject.name == "Trigger_L" || other.gameObject.name == "Trigger_R")
        {
            objetoInteractuable = false;
        }
        myDirection = Direction.None;
    }
}
