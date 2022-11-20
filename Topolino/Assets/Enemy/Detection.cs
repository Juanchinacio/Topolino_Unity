using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            transform.parent.GetComponent<EnemyController>().PlayerDetected();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            transform.parent.GetComponent<EnemyController>().PlayerLosed();
    }
}
