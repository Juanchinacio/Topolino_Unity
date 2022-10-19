using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaCerillas : MonoBehaviour
{
    public GameObject cerilla;
    GameObject cerillaInstancia;

   public string CrearCerilla()
   {
       Debug.Log("Genero Cerilla");
       cerillaInstancia = Instantiate(cerilla);
       return cerillaInstancia.name;
   }

    //public void CrearCerilla()
    //{
    //    Debug.Log("Genero Cerilla");
    //    Instantiate(cerilla);
    //
    //}
}
