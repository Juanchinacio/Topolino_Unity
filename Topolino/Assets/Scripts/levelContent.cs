using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class levelContent : MonoBehaviour
{
    [Header("Variables")]
    public Button botonJugar;
    public int tiempoBronce;
    public int tiempoPlata;
    public int tiempoOro;
    public int mejorTiempo;
    public string nombreNivel;
    public int idiceNivel;

    [Header("GameObjects")]
    public GameObject medallaBronce;
    public GameObject medallaPlata;
    public GameObject medallaOro;
    public TMP_Text text_TiempoBronce;
    public TMP_Text text_TiempoPlata;
    public TMP_Text text_TiempoOro;
    public TMP_Text text_MejorTiempo;

    private void Start()
    {
        medallaBronce.SetActive(false);
        medallaPlata.SetActive(false);
        medallaOro.SetActive(false);
        mejorTiempo = PlayerPrefs.GetInt("Nivel"+ idiceNivel);
        if (mejorTiempo != 0)
        {
            if (mejorTiempo < tiempoBronce)
            {
                medallaBronce.SetActive(true);
            }
            if (mejorTiempo < tiempoPlata)
            {
                medallaPlata.SetActive(true);
            }
            if (mejorTiempo < tiempoOro)
            {
                medallaOro.SetActive(true);
            }
        }
        System.TimeSpan t_bronce = System.TimeSpan.FromSeconds(tiempoBronce);
        System.TimeSpan t_Plata = System.TimeSpan.FromSeconds(tiempoPlata);
        System.TimeSpan t_Oro = System.TimeSpan.FromSeconds(tiempoOro);
        System.TimeSpan t_MejorTiempo = System.TimeSpan.FromSeconds(mejorTiempo);

        if (mejorTiempo == 0)
        {
            text_MejorTiempo.text = "Mejor tiempo: " + "XX:XX:XX";
        }
        else
        {
            text_MejorTiempo.text = "Mejor tiempo: " + string.Format("{0:00}:{1:00}:{2:00}", t_MejorTiempo.Minutes, t_MejorTiempo.Seconds, t_MejorTiempo.Milliseconds);
        }
        text_TiempoBronce.text = "Tiempo < " + string.Format("{0:00}:{1:00}:{2:00}", t_bronce.Minutes, t_bronce.Seconds, t_bronce.Milliseconds);
        text_TiempoPlata.text = "Tiempo < " + string.Format("{0:00}:{1:00}:{2:00}", t_Plata.Minutes, t_Plata.Seconds, t_Plata.Milliseconds);
        text_TiempoOro.text = "Tiempo < " + string.Format("{0:00}:{1:00}:{2:00}", t_Oro.Minutes, t_Oro.Seconds, t_Oro.Milliseconds);
    }

}
