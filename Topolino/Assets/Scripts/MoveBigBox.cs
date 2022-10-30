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

    private GameObject caja;


    public bool puebloCoger = true;

    new_PlayerMovement player_Movement;
    new_Jump player_Jump;

    void Start()
    {
        player_Jump = transform.GetComponent<new_Jump>();
        player_Movement = transform.GetComponent<new_PlayerMovement>();
    }

    public void OnGrab(InputValue value)
    {
        //Debug.Log("QUE PASAAAAAAAAAAAAAAAAAA");
        if (value.isPressed && arrastandoObjeto == false && objetoInteractuable == true && puebloCoger)
        {
            ArrastarObjeto();
        }else if (value.isPressed && arrastandoObjeto == true)
        {
            SoltarObjeto();
        }
    }

    public void ArrastarObjeto()
    {
        puebloCoger = false;
        arrastandoObjeto = true;
        player_Jump.Set_canJump(false);

        float step = playerSpeed * Time.deltaTime; // calculate distance to move

        Vector3 posicionFinal = new Vector3(newPlayerPosition.position.x, transform.position.y, newPlayerPosition.position.z);

        player_Movement.Set_OtherPlayerViewDirection(true);
        player_Movement.Set_OtherViewDirection(objectMove.transform);


        StartCoroutine(ReposicionarJugador(posicionFinal));

        // La caja es hijo de topolino
        // Bloqueo el movimiento en los ejes que me interesa
        if (myDirection == Direction.Top || myDirection == Direction.Bottom)
        {
            Debug.Log("Bloqueo en eje X");
            player_Movement.Set_MoveBlock_X(true);// = true;
        }
        if (myDirection == Direction.Left || myDirection == Direction.Right)
        {
            Debug.Log("Bloqueo en eje Z");
            player_Movement.Set_MoveBlock_Z(true);// = true;
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
        puebloCoger = true;
        player_Jump.Set_canJump(true);
        arrastandoObjeto = false;
        objectMove.transform.parent = null;
        // Quitar restricciones de movimiento de Topolino
        player_Movement.Set_OtherPlayerViewDirection(false);
        player_Movement.Set_OtherViewDirection(null);
        player_Movement.Set_MoveBlock_Z(false);// = false;
        player_Movement.Set_MoveBlock_X(false);// = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Trigger_R")
        {
            myDirection = Direction.Right;
            newPlayerPosition = other.transform.GetChild(0);
            objectMove = other.transform.parent.gameObject;
            objetoInteractuable = true;

            player_Movement.Set_Other_Direction(other.transform);
        }
        if (other.gameObject.name == "Trigger_L")
        {
            myDirection = Direction.Left;
            newPlayerPosition = other.transform.GetChild(0);
            objectMove = other.transform.parent.gameObject;
            objetoInteractuable = true;

            player_Movement.Set_Other_Direction(other.transform);

        }
        if (other.gameObject.name == "Trigger_T")
        {
            myDirection = Direction.Top;
            newPlayerPosition = other.transform.GetChild(0);
            objectMove = other.transform.parent.gameObject;
            objetoInteractuable = true;

            player_Movement.Set_Other_Direction(other.transform);

        }
        if (other.gameObject.name == "Trigger_B")
        {
            myDirection = Direction.Bottom;
            newPlayerPosition = other.transform.GetChild(0);
            objectMove = other.transform.parent.gameObject;
            objetoInteractuable = true;

            player_Movement.Set_Other_Direction(other.transform);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Trigger_B" || other.gameObject.name == "Trigger_T" || other.gameObject.name == "Trigger_L" || other.gameObject.name == "Trigger_R")
        {
            objetoInteractuable = false;
            player_Movement.Set_Other_Direction(null);
            
            
        }
        myDirection = Direction.None;
    }
}
