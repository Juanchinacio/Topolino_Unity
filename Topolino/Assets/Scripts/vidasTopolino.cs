using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidasTopolino : MonoBehaviour
{
    public int numVidas = 10;
    public GameObject jugador;
    public TMP_Text numVidasText;
    public Vector3 ultimo_Checkpoint;

    [SerializeField]
    public AudioSource damage;

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
            SceneManager.LoadScene(6);
            //GameManager.manager.LoadScene(4);
        }
        else
        {
            GameManager.manager.PlayAudio(damage, Audio.sound);
            jugador.transform.position = ultimo_Checkpoint;
        }
    }
}
