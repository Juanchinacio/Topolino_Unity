using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolin : MonoBehaviour
{
    public float force = 10;

    [SerializeField]
    public AudioSource boing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "trampolin")
        {
            GameManager.manager.PlayAudio(boing, Audio.sound);
            Debug.Log("TRAMPOSALTO");
            other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
        }  
    }
}
