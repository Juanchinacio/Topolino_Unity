using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Embestidor, Timido,Prefab
}

public class Detection : MonoBehaviour
{
    public EnemyType enemyType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (enemyType)
            {
                case EnemyType.Prefab:
                    transform.parent.GetComponent<EnemyController>().PlayerDetected();
                    Debug.Log("Detectado Prefab!!");
                    break;

                case EnemyType.Embestidor:
                    Debug.Log("Detectado Embestidor!!");
                    transform.parent.GetComponent<EmbestidorController>().PlayerDetected();
                    break;

                case EnemyType.Timido:
                    Debug.Log("Detectado Timido!!");
                    transform.parent.GetComponent<TimidoController>().PlayerDetected();
                    break;
            }
        }

        if(enemyType == EnemyType.Timido)
        {
            if((other.gameObject.tag == "Cerilla" && other.gameObject.GetComponent<Cerilla>().estaEncendida) || other.gameObject.tag == "Fuego")
            {
                Debug.Log("Fuegoooo!!");
                transform.parent.GetComponent<TimidoController>().FireDetected();
            }

        }
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (enemyType == EnemyType.Timido)
        {
            if ((other.gameObject.tag == "Cerilla" && other.gameObject.GetComponent<Cerilla>().estaEncendida) || other.gameObject.tag == "Fuego")
            {
                Debug.Log("Fuegoooo!!");
                transform.parent.GetComponent<TimidoController>().FireDetected();
            }

        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switch (enemyType)
            {
                case EnemyType.Prefab:
                    transform.parent.GetComponent<EnemyController>().PlayerLosed();
                    break;

                case EnemyType.Embestidor:
                    transform.parent.GetComponent<EmbestidorController>().PlayerLosed();
                    break;
                case EnemyType.Timido:
                    transform.parent.GetComponent<TimidoController>().PlayerLosed();
                    break;
            }
        }

        if (enemyType == EnemyType.Timido)
        {
            if ((other.gameObject.tag == "Cerilla" && other.gameObject.GetComponent<Cerilla>().estaEncendida) || other.gameObject.tag == "Fuego")
            {
                Debug.Log("Fuegoooo!!");
                transform.parent.GetComponent<TimidoController>().FireLosed();
            }

        }

    }
}
