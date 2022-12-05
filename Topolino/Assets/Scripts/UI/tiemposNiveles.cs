using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tiemposNiveles : MonoBehaviour
{
    public int idNivel;
    float tiempo = 0;
    public TMP_Text indicadorTiempo;

    public void Update()
    {
        tiempo += Time.deltaTime;
        indicadorTiempo.text = tiempo + " s";
    }

    public void GuardarTiempo()
    {
        string aux = "Nivel" + idNivel;

        if (PlayerPrefs.GetInt(aux) < (int)tiempo)
        {
            PlayerPrefs.SetInt(aux, (int)tiempo);
        }
        else
        {

        }
        
    }
}
