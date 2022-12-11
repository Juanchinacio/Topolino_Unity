using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public enum EmbestidorMode
{
    Path, Atack, Shout
}

public class EmbestidorController : MonoBehaviour
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
    [SerializeField] public float walkingSpeed;
    [SerializeField] public float runningSpeed;

    private NavMeshAgent agent;
    private EmbestidorMode currentMode = EmbestidorMode.Path;
    private int currentDestination = 0;

    private bool canShout;
    private bool shouting = false;

    public AudioSource _grito;

    [SerializeField] Animator _animator;
    private int _idWalk;
    private int _idCharge;
    private int _idAtack;

    void Start()
    {
        _idWalk = Animator.StringToHash("isWalking");
        _idCharge = Animator.StringToHash("isCharging");
        _idAtack = Animator.StringToHash("isAtacking");

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
            case EmbestidorMode.Path:
                //Set walking
                agent.speed = walkingSpeed;

                //Set animation
                _animator.SetBool(_idWalk, true);
                _animator.SetBool(_idCharge, false);
                
                CheckDestination();

                break;

            case EmbestidorMode.Atack:
                
                //Set animation
                _animator.SetBool(_idWalk, false);
                _animator.SetBool(_idCharge, true);

                //Set runnning
                agent.speed = runningSpeed;

                AtackPlayer();

                break;

            case EmbestidorMode.Shout:
                break;
        }
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
            currentMode = EmbestidorMode.Atack;
        }
    }

    //Player outside trigger detecction
    public void PlayerLosed()
    {
        if (!shouting)
        {
            detected.SetActive(false);
            currentMode = EmbestidorMode.Path;
            agent.SetDestination(target[currentDestination].position);
        }
    }

    public void ShoutDetected()
    {
        detected.SetActive(true);
        canShout = false;
        //Reload Shout
        if (shouter)
            StartCoroutine(ReloadShout());

        currentMode = EmbestidorMode.Atack;

    }

    public void AtackPlayer()
    {
        //Move to player position
        agent.SetDestination(player.transform.position);
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

    IEnumerator Shout()
    {
        //Stop agent
        agent.isStopped = true;

        //Start shouting
        currentMode = EmbestidorMode.Shout;
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
        currentMode = EmbestidorMode.Atack;

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
