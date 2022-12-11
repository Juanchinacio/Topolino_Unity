using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaMovil : MonoBehaviour
{
    public bool interactuable;
    public List<Transform> wayPoints;
    public bool puedoInteractuar = true;
    private Transform nextWayPoint;
    public float velocidad;
    public int idx = 0;
    public int aux;

    public GameObject plataforma;


    [SerializeField]
    public AudioSource activate;

    void Awake()
    {
        plataforma = transform.GetChild(0).gameObject;
        // Guardar todos los wayPoints
        for (int i = 1; i < transform.childCount; i++)
        {
            wayPoints.Add(transform.GetChild(i).transform);
        }
        // Los way point no son hijos de la plataforma
        //transform.DetachChildren();

        if (wayPoints.Count > 0)
        {
            transform.position = wayPoints[0].transform.position;
            idx = 0;
            nextWayPoint = wayPoints[idx];
        }
        else
        {
            Debug.Log("No hay wayPoints");
        }
        
    }

    void Update()
    {
        if (plataforma.transform.position != nextWayPoint.position)
        {
            //puedoInteractuar = false;
            plataforma.transform.position = Vector3.MoveTowards(plataforma.transform.position,nextWayPoint.position, velocidad * Time.deltaTime);
        }
        else if (interactuable == false)
        {
            if (idx < wayPoints.Count - 1)
            {
                idx++;
            }
            else
            {
                idx = 0;
            }
            nextWayPoint = wayPoints[idx];
        }
        else
        {
            //puedoInteractuar = true;
        }
        
    }

    public void AvanzarPosicion()
    {
        GameManager.manager.PlayAudio(activate, Audio.sound);

        nextWayPoint = wayPoints[0];
        ////if (puedoInteractuar == true)
        ////{
        //    idx++;
        //    aux = Mathf.Abs(idx % wayPoints.Count);
        //    nextWayPoint = wayPoints[aux];
        ////}
    }

    public void RetrocederPosicion()
    {
        GameManager.manager.PlayAudio(activate, Audio.sound);
        nextWayPoint = wayPoints[1];
        ////if (puedoInteractuar == true)
        ////{
        //    idx--;
        //    aux = Mathf.Abs(idx % wayPoints.Count);
        //    nextWayPoint = wayPoints[aux];
        ////}  
    }

}
