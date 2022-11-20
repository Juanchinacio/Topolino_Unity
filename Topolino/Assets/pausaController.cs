using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pausaController : MonoBehaviour
{
    public GameObject pausa;
    bool activado = false;

    public Button buttom_volverMenu;
    public Button buttom_cerrarPausa;

    
    public void OnPausa(InputValue value)
    {
        if (activado == false)
        {
            pausa.SetActive(true);
            activado = true;
        }
        
    }

    public void volverMenu()
    {
        GameManager.manager.LoadScene(0);
    }
    public void cerrarPausa()
    {
        pausa.SetActive(false);
        activado = false;
    }

    private void Start()
    {
        pausa.SetActive(false);
    }
}
