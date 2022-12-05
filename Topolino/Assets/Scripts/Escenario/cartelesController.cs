using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cartelesController : MonoBehaviour
{
    public GameObject UI;
    public TMP_Text recuadroTextoUI;

    public void ActivarUI()
    {
        UI.SetActive(true);
    }
    public void DesactivarUI()
    {
        UI.SetActive(false);
    }

    public void MostarTexto(string _mensaje)
    {
        StartCoroutine(Escribir(_mensaje));
    }

    IEnumerator Escribir(string _mensaje)
    {
        recuadroTextoUI.text = "";
        foreach (char caracter in _mensaje.ToCharArray())
        {
            recuadroTextoUI.text += caracter;
            yield return new WaitForSeconds(0.08f);
        }
    }
}
