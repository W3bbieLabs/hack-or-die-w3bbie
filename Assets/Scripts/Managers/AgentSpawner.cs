using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class AgentSpawner : NetworkBehaviour
{
    public GameObject agentPrefab;
    public GameObject door;

    [SerializeField] float spawnRadius = 3f;

    public int enemyMultiplier = 1;
    public int level = 1;
    private int enemyCount;
    private Animator doorAnimator;

    void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
    }

    void Update()
    {
        /*
        if (isLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                AddAgents();
            }
        }*/
    }

    [Command]
    public void AddAgents()
    {
        enemyCount = level * enemyMultiplier;
        Debug.Log("AGENT Count: " + enemyCount);
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPos = GetRandomPoint(new Vector3(0, 0, 0), spawnRadius);
            GameObject _agent = Instantiate(agentPrefab, randomPos, Quaternion.identity);
            NetworkServer.Spawn(_agent);
        }

        if (enemyCount == 25)
        {
            doorAnimator.SetBool("Open", true);
        }
    }

    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;
        NavMeshHit hit; // NavMesh Sampling Info Container
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);
        Vector3 newPos = new Vector3(hit.position.x, 1.25f, hit.position.z);
        return newPos;
    }
}