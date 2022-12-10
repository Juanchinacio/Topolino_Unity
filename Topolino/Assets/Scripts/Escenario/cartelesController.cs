using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cartelesController : MonoBehaviour
{
    public GameObject UI;
    public TMP_Text recuadroTextoUI;
    public bool escribiendo = false;

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
        if (escribiendo == false)
        {
            escribiendo = true;
            recuadroTextoUI.text = "";
            foreach (char caracter in _mensaje.ToCharArray())
            {
                recuadroTextoUI.text += caracter;
                yield return new WaitForSeconds(0.08f);
            }
            escribiendo = false;
        }
        
    }
}
