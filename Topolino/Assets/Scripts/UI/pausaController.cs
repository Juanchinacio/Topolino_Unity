using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class pausaController : MonoBehaviour
{
    public GameObject pausa;
    bool activado = false;

    public Button buttom_volverMenu;
    public Button buttom_cerrarPausa;
    public tiemposNiveles tiemposNiveles;

    
    

    public void OnPausa(InputValue value)
    {
        if (activado == false)
        {
            pausa.SetActive(true);
            activado = true;
            tiemposNiveles.pausarCronometro();
            Time.timeScale = 0;
        }

    }

    public void volverMenu()
    {
        GameManager.manager.LoadScene(0);
        
    }
    public void cerrarPausa()
    {
        tiemposNiveles.reaudarCronometro();
        pausa.SetActive(false);
        activado = false;
        Time.timeScale = 1;
    }

    private void Start()
    {
        tiemposNiveles = GameObject.Find("Controlador Tiempo").GetComponent<tiemposNiveles>();

        pausa.SetActive(false);
    }
}
