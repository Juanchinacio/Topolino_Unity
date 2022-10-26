using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerPickObject : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Object(Top)") || other.gameObject.CompareTag("Object(Front)") || other.gameObject.CompareTag("Object(Physics)"))
        {
            player.GetComponent<PickObject>().contadorObjetos--;
            player.GetComponent<PickObject>().Objetos.Remove(other);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object(Top)") || other.gameObject.CompareTag("Object(Front)") || other.gameObject.CompareTag("Object(Physics)"))
        {
            player.GetComponent<PickObject>().contadorObjetos++;
            player.GetComponent<PickObject>().Objetos.Add(other);
        }
    }
}
