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
        

        text_TiempoBronce.text = "Tiempo < " + tiempoBronce + "s";
        text_TiempoPlata.text = "Tiempo < " + tiempoPlata + "s";
        text_TiempoOro.text = "Tiempo < " + tiempoBronce + "s";
        text_MejorTiempo.text = "Mejor tiempo: " + mejorTiempo + "s";
    }

}
