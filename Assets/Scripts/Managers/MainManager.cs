using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using Mirror;

public class MainManager : NetworkBehaviour
{
    public static MainManager Instance;
    [SerializeField] GameObject agentPrefab;
    Player player;

    public int enemyMultiplier = 1;

    public int level = 1;

    public bool isSpawned = false;

    [SerializeField] float spawnRadius = 5f;

    public bool isInit = false;

    public AudioSource MainMenuMusic;

    void Awake()
    {
        if (!isLocalPlayer)
            return;

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }



    public override void OnStartClient()
    {
        //Debug.Log("OnStartClient MainManager");
        //if (isServer)
        //agent.CmdAddAgents(level, enemyMultiplier, spawnRadius);
        player = GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<Player>();
        base.OnStartClient();
        if(level >= 10)
        {
            SoundManager.instance.PlayLevelTheme2();
        }
        else
        {
            SoundManager.instance.PlayLevelTheme();
        }
        
       
    }

    public override void OnStartServer()
    {
        player = GameObject.FindGameObjectWithTag("LocalPlayer").GetComponent<Player>();
        base.OnStartClient();
        
    }




    public void ResetGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //CmdAddAgents();
        if (isServer)
        {
            player.AddAgents(level); // is called on the server
            //player.CmdAddAgents(level);
        }

    }

    void LevelComplete()
    {
        level += 1;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetGame();
        if (level % 5 == 0)
        {
          SoundManager.instance.PlayLevelComplete();  
        }
        
    }

    public void GameOver()
    {
        level = 1;
        ResetGame();
        //DestroyAll("Agent");
        SoundManager.instance.PlayLevelFailed();
    }

    private int GetAgentCount()
    {
        return GameObject.FindGameObjectsWithTag("Agent").Length;
    }

    void DestroyAll(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
        ResetGame();
    }

    IEnumerator checkAgentCount()
    {
        //Debug.Log("start");
        yield return new WaitForSeconds(1);
        Debug.Log("Agent died " + GetAgentCount());
        if (GetAgentCount() <= 0)
        {
            //Debug.Log("Killed all agents.");
            LevelComplete();
        }
    }

    public void AgentDied()
    {
        Debug.Log("AgentDied");
        StartCoroutine(checkAgentCount());
    }

    public void PlayerDied()
    {
        Debug.Log("player died");
        GameOver();
    }

    /*
    public static Vector3 GetRandomPoint(Vector3 center, float maxDistance)
    {
        Vector3 randomPos = Random.insideUnitSphere * maxDistance + center;
        NavMeshHit hit; // NavMesh Sampling Info Container
        NavMesh.SamplePosition(randomPos, out hit, maxDistance, NavMesh.AllAreas);
        Vector3 newPos = new Vector3(hit.position.x, 1.25f, hit.position.z);
        return newPos;
    }
    */
}
