using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public enum EmbestidorMode
{
    Path, Atack, Shout, Charge
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
    [SerializeField] public float timeCharge;
    [SerializeField] public float timeAtack;

    private NavMeshAgent agent;
    public EmbestidorMode currentMode = EmbestidorMode.Path;
    private int currentDestination = 0;

    private bool canShout;
    private bool shouting = false;
    private bool canCharge = true;
    private bool charging = false;

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
                agent.isStopped = false;
                agent.speed = walkingSpeed;

                //Set animation
                _animator.SetBool(_idWalk, true);

                CheckDestination();

                break;

            case EmbestidorMode.Charge:

                if (charging)
                    break;

                agent.SetDestination(player.transform.position);

                //Stop
                agent.isStopped = true;
                agent.speed = runningSpeed;

                //Set animation
                _animator.SetBool(_idWalk, false);
                _animator.SetBool(_idAtack, false);
                _animator.SetBool(_idCharge, true);

                StartCoroutine(ChargeAtack());

                break;

            case EmbestidorMode.Atack:
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
            currentMode = EmbestidorMode.Charge;
        }
    }

    //Player outside trigger detecction
    public void PlayerLosed()
    {
        if (!shouting)
        {
            if (!charging)
            {
                detected.SetActive(false);
                currentMode = EmbestidorMode.Path;
                agent.SetDestination(target[currentDestination].position);
            }
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

    IEnumerator ChargeAtack()
    {
        charging = true;

        yield return new WaitForSeconds(timeCharge);

        currentMode = EmbestidorMode.Atack;
        agent.isStopped = false;

        _animator.SetBool(_idCharge, false);
        _animator.SetBool(_idAtack, true);

        float timeToStop = 0;
        while (timeToStop < timeAtack)
        {
            timeToStop += Time.deltaTime;
            agent.SetDestination(player.transform.position);

            yield return null;
        }

        charging = false;
        currentMode = EmbestidorMode.Path;
        agent.SetDestination(target[currentDestination].position);
        _animator.SetBool(_idAtack, false);
        detected.SetActive(false);
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
