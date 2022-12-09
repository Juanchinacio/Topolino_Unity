using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class tiemposNiveles : MonoBehaviour
{
    public int idNivel;
    float tiempo = 0;
    public TMP_Text indicadorTiempo;
    public bool pausado = false;

    public void Update()
    {
        if (pausado == false)
            tiempo += Time.deltaTime;

        System.TimeSpan t = System.TimeSpan.FromSeconds(tiempo);
        string niceTime = string.Format("{0:00}:{1:00}:{2:00}", t.Minutes, t.Seconds, t.Milliseconds);

        indicadorTiempo.text = niceTime;
    }

    public void pausarCronometro()
    {
        pausado = true;
    }

    public void reaudarCronometro()
    {
        pausado = false;
    }

    public void GuardarTiempo()
    {
        string aux = "Nivel" + idNivel;

        if (PlayerPrefs.GetInt(aux) < (int)tiempo)
        {
            PlayerPrefs.SetInt(aux, (int)tiempo);
        }
    }
}
