using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class Agent : Unit
{

    [Header("Bullet")]
    [SerializeField] GameObject agentPrefab;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    NavMeshAgent navMeshAgent;
    float speedMultiplier = 2f;
    [SerializeField] int bulletDamage = 10;

    MainManager mainManager;

    RaycastHit hit;

    public override void OnStartClient()
    {
        base.OnStartClient();
        mainManager = GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<MainManager>();
    }

    public override void OnStartServer()
    {
        base.OnStartServer();
        mainManager = GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<MainManager>();
    }

    /*

    [Command]
    public void CmdAddAgents()
    {
        int enemyCount = level * enemyMultiplier;
        Debug.Log("AGENT Count: " + enemyCount);
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPos = GetRandomPoint(new Vector3(0, 0, 0), spawnRadius);
            GameObject _agent = Instantiate(agentPrefab, randomPos, Quaternion.identity);
            NetworkServer.Spawn(_agent);
        }
    }*/

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed *= speedMultiplier;
    }
    void FixedUpdate()
    {
        SensePlayer();
        CheckShoot();
    }

    void shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }

    void CheckShoot()
    {
        Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "LocalPlayer")
            {
                shoot();
                SoundManager.instance.PlayEnemyUzi();
            }
        }
    }

    void SensePlayer()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, detectionRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.gameObject.tag == "LocalPlayer")
            {
                navMeshAgent.destination = collider.transform.position;
            }
        }
    }


    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter enter on agent.cs");
        int bulletDamage = other.GetComponent<Bullet>().bulletDamage;
        TakeHit(bulletDamage);
    }

    public void TakeHit(int damage)
    {
        Debug.Log("TakeHit");
        health -= damage;
        if (health <= 0)
        {
            //Destroy(gameObject);
            NetworkServer.Destroy(gameObject);
            mainManager.AgentDied();

            //MainManager.Instance.GetAgent
            //Debug.Log(MainManager.Instance);
            //MainManager.Instance.AgentDied();
        }
    }
}
