using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class vidasTopolino : MonoBehaviour
{
    public int numVidas = 10;
    public GameObject jugador;
    public TMP_Text numVidasText;
    public Vector3 ultimo_Checkpoint;

    private void Start()
    {
        ultimo_Checkpoint = transform.position;
        numVidasText.text = numVidas.ToString();
    }

    public void Morir()
    {
        numVidas--;
        numVidasText.text = numVidas.ToString();
        if (numVidas <= 0)
        {
            // Ir a pantalla de derrota
            GameManager.manager.LoadScene(4);
        }
        else
        {
            jugador.transform.position = ultimo_Checkpoint;
        }
    }
}
