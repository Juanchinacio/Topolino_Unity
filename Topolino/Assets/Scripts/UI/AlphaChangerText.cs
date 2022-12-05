using UnityEngine;
using System.Collections;

//agregamos nuevos using para poder usar el New GUI
using UnityEngine.UI;
using TMPro;

public class AlphaChangerText : MonoBehaviour
{
    //Agregamos las variables de Texto y Strings
    TextMeshProUGUI text;

     //Agregamos una bandera que sera nuestro identificador para cambiar el texto
     [SerializeField] float LightSpeed;
    [SerializeField] float maxValue;
    [SerializeField] float minValue;


    void Start () 
     {
        //obtenemos el componente del texto
        text = GetComponent<TextMeshProUGUI>();

          //llamamos al coroutine de la funcion que cambia el alpha del texto
          StartCoroutine(ChangerAlpha());
    }

    //funcion para que parpadee el texto
    public IEnumerator ChangerAlpha()
    {
        bool increasing = true;
        float valueToAdd = Time.deltaTime * LightSpeed;
        float currentValue = 0f;

        while (true)
        {
            if (increasing)
            {
                currentValue += valueToAdd;
            }
            else
            {
                currentValue -= valueToAdd;
            }
            if(currentValue >= maxValue)
            {
                increasing = false;
                currentValue = maxValue;
            }
            else if(currentValue<= minValue)
            {
                increasing = true;
                currentValue = minValue;
            }
            Debug.Log(currentValue);
            text.alpha = currentValue;
            yield return null;
        }
    }
} 
