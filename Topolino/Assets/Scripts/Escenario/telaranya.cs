using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telaranya : MonoBehaviour
{
    public Material quemado;
    public float tiempoQuemado = 1f;
    public void Quemar() 
    {

        StartCoroutine(QuemarTelaranya().GetEnumerator());
    }

    IEnumerable QuemarTelaranya()
    {
        Debug.Log("Me estoy quemando");
        transform.GetComponent<MeshRenderer>().material = quemado;
        yield return new WaitForSeconds(1);
        Debug.Log("Me he quemado");
        Destroy(gameObject);
    }
}
