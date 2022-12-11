using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public enum TimidoMode
{
    Waiting, Transform, Undotransform, Walking, Escaping, Shout
}
public class TimidoController : MonoBehaviour
{
    //Variables
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject detected;
    [SerializeField] public GameObject shoutSphere;
    [SerializeField] public Transform[] target;

    [SerializeField] public float timeShouting;
    [SerializeField] public float timeReloadShout;
    [SerializeField] public float shoutSize;
    [SerializeField] public bool shouter;

    private NavMeshAgent agent;
    public TimidoMode currentMode = TimidoMode.Waiting;
    private int currentDestination = 0;
    public bool isStopped;

    private bool canShout;
    private bool shouting = false;
    private Vector3 initialPosition;

    public AudioSource _grito;

    [SerializeField] Animator _animator;
    private int _idIdelBox;
    private int _idUndoTransform;
    private int _idWalk;
    private int _idTransform;
    private int _idEscape;

    void Start()
    {
        initialPosition = GetComponent<Transform>().position;

        _idIdelBox = Animator.StringToHash("isIdelBox");
        _idUndoTransform = Animator.StringToHash("isUndoTransform");
        _idWalk = Animator.StringToHash("isWalk");
        _idTransform = Animator.StringToHash("isTransform");
        _idEscape = Animator.StringToHash("isEscape");

        if (shouter)
            canShout = true;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target[0].position);
    }

    private void Update()
    {
        //Decide action depending on Mode
        switch (currentMode)
        {
            case TimidoMode.Waiting:

                _animator.SetBool(_idTransform, false);

                _animator.SetBool(_idIdelBox, true);

                Idel();

                break;

            case TimidoMode.Transform:

                _animator.SetBool(_idEscape, false);
                _animator.SetBool(_idWalk, false);

                _animator.SetBool(_idTransform, true);

                Transform();

                break;


            case TimidoMode.Undotransform:

                _animator.SetBool(_idUndoTransform, true);

                UndoTransform();

                break;

            case TimidoMode.Walking:

                //Set animation
                _animator.SetBool(_idEscape, false);
                _animator.SetBool(_idUndoTransform, false);

                _animator.SetBool(_idWalk, true);

                Walking();

                break;


            case TimidoMode.Escaping:

                //Set animation
                _animator.SetBool(_idEscape, true);
                _animator.SetBool(_idWalk, false);

                Escape();

                break;
        }

        isStopped = agent.isStopped;
    }


    public void FireDetected()
    {
        GameManager.manager.PlayAudio(_grito, Audio.sound);

        currentMode = TimidoMode.Escaping;
    }
    public void FireLosed()
    {
        currentMode = TimidoMode.Transform;
    }

    //Player inside trigger detecction
    public void PlayerDetected()
    {
        GameManager.manager.PlayAudio(_grito, Audio.sound);

        if (!shouting && canShout)
        {
            StartCoroutine(Shout());
        }
        else
        {
            detected.SetActive(true);
            currentMode = TimidoMode.Undotransform;
        }
    }

    //Player outside trigger detecction
    public void PlayerLosed()
    {
        if (!shouting)
        {
            detected.SetActive(false);
            currentMode = TimidoMode.Transform;
        }
    }

    public void ShoutDetected()
    {
        detected.SetActive(true);
        canShout = false;
        //Reload Shout
        if (shouter)
            StartCoroutine(ReloadShout());

        currentMode = TimidoMode.Undotransform;

    }

    //Checks the position inside path, sets next destination
    public void CheckDestination()
    {
        bool checkX = transform.position.x == target[currentDestination].position.x;
        bool checkZ = transform.position.z == target[currentDestination].position.z;

        if (checkX && checkZ)
        {
            currentDestination++;

            if (currentDestination == target.Length)
                currentDestination = 0;

            agent.SetDestination(target[currentDestination].position);
        }
    }


    //Modes
    private void Idel()
    {
        agent.isStopped = true;
        
    }
    private void Transform()
    {
        agent.isStopped = true;
        currentMode = TimidoMode.Waiting;
    }

    private void UndoTransform()
    {
        agent.isStopped = true;
        currentMode = TimidoMode.Walking;
    }

    public void Walking()
    {
        agent.isStopped = false;

        //Move to player position
        agent.SetDestination(player.transform.position);
    }

    public void Atack()
    {
        //Move to player position
        agent.isStopped = true;
    }

    public void Escape()
    {
        agent.isStopped = false;

        //Move to player position
        agent.SetDestination(initialPosition);
    }



    private 


    IEnumerator Shout()
    {
        //Stop agent
        agent.isStopped = true;

        //Start shouting
        currentMode = TimidoMode.Shout;
        GameObject sphere = Instantiate(shoutSphere, transform.position, Quaternion.identity);

        float timeLeft = timeShouting;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            sphere.transform.localScale += new Vector3(shoutSize, shoutSize, shoutSize);
            yield return null;
        }

        //Stop Shouting
        Destroy(sphere);
        agent.isStopped = false;
        canShout = false;
        detected.SetActive(true);
        currentMode = TimidoMode.Walking;

        //Reload Shout
        StartCoroutine(ReloadShout());
    }

    IEnumerator ReloadShout()
    {
        float timeLeft = timeReloadShout;

        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }
        canShout = true;
        yield return null;
    }


}