using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public enum EnemyMode
{
    Path, Atack, Shout
}

public class EnemyController : MonoBehaviour
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
    private EnemyMode currentMode = EnemyMode.Path;
    private int currentDestination = 0;

    private bool canShout;
    private bool shouting = false;

    void Start()
    {
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
            case EnemyMode.Path:
                CheckDestination();
                break;
            case EnemyMode.Atack:
                agent.SetDestination(player.transform.position);
                break;
            case EnemyMode.Shout:
                break;
        }
    }

    //Player inside trigger detecction
    public void PlayerDetected()
    {
        
        if (!shouting && canShout)
        {
            StartCoroutine(Shout());
        }
        else
        {
            detected.SetActive(true);
            currentMode = EnemyMode.Atack;
        }
    }

    //Player outside trigger detecction
    public void PlayerLosed()
    {
        if (!shouting)
        {
            detected.SetActive(false);
            currentMode = EnemyMode.Path;
            agent.SetDestination(target[currentDestination].position);
        }
    }

    public void ShoutDetected()
    {
        detected.SetActive(true);
        canShout = false;
        //Reload Shout
        if(shouter)
            StartCoroutine(ReloadShout());

        currentMode = EnemyMode.Atack;

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
        currentMode = EnemyMode.Shout;
        GameObject sphere = Instantiate(shoutSphere, transform.position, Quaternion.identity);

        float timeLeft = timeShouting;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            sphere.transform.localScale += new Vector3(shoutSize, shoutSize, shoutSize) ;
            yield return null;
        }

        //Stop Shouting
        Destroy(sphere);
        agent.isStopped = false;
        canShout = false;
        detected.SetActive(true);
        currentMode = EnemyMode.Atack;

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
