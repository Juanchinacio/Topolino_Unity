using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class checkpoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("colision con checkpoint");
            other.GetComponent<vidasTopolino>().ultimo_Checkpoint = this.transform.parent.GetChild(1).GetComponent<Transform>().position;
        }
    }
}
