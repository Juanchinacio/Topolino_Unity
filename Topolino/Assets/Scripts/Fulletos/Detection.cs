using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Embestidor,Prefab
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
            }
        }
    }
}
