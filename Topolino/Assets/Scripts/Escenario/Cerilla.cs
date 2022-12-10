using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerilla : MonoBehaviour
{
    public bool estaEncendida = false;
    public float ActualCooldownDuration;
    public float CooldownDuration = 10;
    public bool IsAvailable;
    public GameObject fire;
    public GameObject particulas;
    public void Update()
    {
        if (IsAvailable)
        {
            ActualCooldownDuration -= 1 * Time.deltaTime;
        }
        if (ActualCooldownDuration <= 0)
        {
            Apagar();
        }

    }

    public void Encender()
    {
        estaEncendida = true;
        //transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        //gameObject.GetComponent<Renderer>().material.color = Color.red;
        particulas.SetActive(true);
        fire.GetComponent<Collider>().enabled = true;

        ActualCooldownDuration = CooldownDuration;
        IsAvailable = true;
    }
    public void Apagar()
    {
        estaEncendida = false;
        particulas.SetActive(false);
        //transform.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        //gameObject.GetComponent<Renderer>().material.color = Color.white;
        fire.GetComponent<Collider>().enabled = false;
        IsAvailable = false;
    }

    // Tiempo apagado

    public IEnumerator StartCooldown()
    {
        IsAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        IsAvailable = true;
    }
}
