using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FulletoTimido : MonoBehaviour
{
    private Animator ani;
    private Quaternion angulo; //para rotar al enemigo
    private float grado;

    public GameObject jugador;
    private bool atacando;

    public NavMeshAgent agente;
    public float distancia_ataque;
    public float radio_enemigo;

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        comportamiento_Fulleto();
    }

    public void comportamiento_Fulleto()
    {
        //Código para cuando el jugador está dentro del rango del enemigo
        if(Vector3.Distance(transform.position, jugador.transform.position) < radio_enemigo)
        {
            ani.SetBool("Transformarse", false);
            ani.SetBool("Destransformarse", true);

            //El enemigo rota para mirar al jugador
            var lookPos = jugador.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);

            agente.enabled = true;
            agente.SetDestination(jugador.transform.position);

        }
        //Código para cuando el jugador está fuera del rango del enemigo
        else if (Vector3.Distance(transform.position, jugador.transform.position) > radio_enemigo)
        {
            agente.enabled = false;
            ani.SetBool("Transformarse", true);
            ani.SetBool("Destransformarse", true);
        }
    }

    public void Final_Ani()
    {
        //Animaciones
        atacando = false; 
    }
}
