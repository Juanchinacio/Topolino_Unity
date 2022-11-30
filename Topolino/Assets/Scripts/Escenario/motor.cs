using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class motor : MonoBehaviour
{
    public bool rotacionConstante;
    public float velocidad;
    public bool puedoRotar = true;

    void Update()
    {
        if (rotacionConstante)
        {
            transform.Rotate(0, (velocidad * 10) * Time.deltaTime, 0); //rotates around z axis
        }
    }

    public void ActivarRotacionConstante(float _velocidad)
    {
        rotacionConstante = true;
        velocidad = _velocidad;
    }
    public void DesactivarRotacionConstante()
    {
        rotacionConstante = false;
        velocidad = 0f;
    }

    public void RotacionPorGrados(float _grados)
    {
        if (puedoRotar == true)
        {
            StartCoroutine(Rotacion(_grados));
        }
    }


    IEnumerator Rotacion(float _grados)
    {
        puedoRotar = false;
        // Calculo de la nueva rotacion y ejecucion de la rotacion
        Debug.Log("Rotacion de: " + _grados);
        float nuevoAngulo = transform.rotation.eulerAngles.y + _grados;
        Vector3 rotacionFinal = new Vector3(transform.rotation.eulerAngles.x, nuevoAngulo, transform.rotation.eulerAngles.z);
        transform.DORotate(rotacionFinal, velocidad);
        yield return new WaitForSeconds(velocidad);
        puedoRotar = true;
    }
}
