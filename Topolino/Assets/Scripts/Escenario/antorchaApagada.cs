using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class antorchaApagada : MonoBehaviour
{
    public bool estaEncendida = false;
    public float ActualCooldownDuration;
    public float CooldownDuration = 10;
    public bool IsAvailable;
    public GameObject fire;
    public GameObject particulas;

    public dobleActivacion DobleActivacion;

    public void Update()
    {
        if (IsAvailable)
        {
            ActualCooldownDuration -= 1 * Time.deltaTime;
        }
        if (ActualCooldownDuration <= 0 && estaEncendida == true)
        {
            _Apagar();
        }

    }

    private void Start()
    {
        _Apagar();
        DobleActivacion.cantidadActual = 0;
    }

    public void _Encender()
    {
        
        

        if (estaEncendida == false)
        {
            DobleActivacion.Mas();
            estaEncendida = true;
        }

        particulas.SetActive(true);
        fire.GetComponent<Collider>().enabled = true;

        ActualCooldownDuration = CooldownDuration;
        IsAvailable = true;
    }
    public void _Apagar()
    {
        if (estaEncendida == true)
        {
            DobleActivacion.Menos();
            estaEncendida = false;
        }

        particulas.SetActive(false);

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cerilla" )
        {
            if (other.GetComponent<Cerilla>().estaEncendida == true)
            {
                _Encender();
            }
            
        }
    }
}
