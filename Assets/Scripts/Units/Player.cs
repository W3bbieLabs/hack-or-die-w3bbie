using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using Mirror;

public class Player : Unit
{
    Camera cam;
    [SerializeField] GameObject agentPrefab;

    [SerializeField] Animator anim;

    [SerializeField] Animator bluAnim;

    [SerializeField] Transform orientation;
    private PlayerInput playerInput;

    [SerializeField] Collider playerCollider;
    protected Rigidbody rb;

    [Header("Movement")]
    [SerializeField] float rotationSpeed = 10;
    bool readyToJump = true;
    float distToGround;

    [Header("Bullets")]
    //[SerializeField] private int maxBullets = 10;
    [SerializeField] private int bulletCount = 10;
    [SerializeField] float bulletSpeed = 10f;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    Camera mainCam;
    MainManager mainManager;
    [SerializeField] int enemyMultiplier = 1;

    [Header("Enemies")]
    [SerializeField] float spawnRadius = 1f;
    [SerializeField] Vector3[] spawnPoints;

    private Vector3 sp;

    public override void OnStartClient()
    {

        base.OnStartClient();
        CmdAddAgents(1);
        //Debug.Log("CmdAddAgents() OnStartClient pLAYER.CS");
        mainManager = GetComponent<MainManager>();
    }

    public Vector3 getRandomSpawnPoint()
    {
        var randomIndex = Random.Range(0, spawnPoints.Length);
        return spawnPoints[randomIndex];
        //var randomIndex = random.Next(0, spawnPoints.Length);
    }

    [Command]
    public void CmdAddAgents(int level)
    {
        int enemyCount = level * enemyMultiplier;
        Debug.Log("AGENT Count: " + enemyCount);
        for (int i = 0; i < enemyCount; i++)
        {

            sp = getRandomSpawnPoint();
            Debug.Log("Spawning " + i + " at " + sp);
            Vector3 randomPos = GetRandomPoint(sp, spawnRadius);
            GameObject _agent = Instantiate(agentPrefab, randomPos, Quaternion.identity);
            NetworkServer.Spawn(_agent);
        }
    }

    // This is only called when we have made sure we isServer=True 
    public void AddAgents(int level)
    {
        int enemyCount = level * enemyMultiplier;
        Debug.Log("AGENT Count: " + enemyCount);
        for (int i = 0; i < enemyCount; i++)
        {
            sp = getRandomSpawnPoint();
            Debug.Log("Spawning " + i + " at " + sp);
            Vector3 randomPos = GetRandomPoint(sp, spawnRadius);
            GameObject _agent = Instantiate(agentPrefab, randomPos, Quaternion.identity);
            NetworkServer.Spawn(_agent);
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

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.PlayerMain.Enable();
        cam = Camera.main;
        //Debug.Log(isLocalPlayer);
    }
    private void Start()
    {
        distToGround = playerCollider.bounds.extents.y;
        rb = GetComponent<Rigidbody>();
        //Debug.Log(anim);
    }

    private void FixedUpdate()
    {
        //Debug.Log(isLocalPlayer);
        if (isLocalPlayer)
        {
            UpdateMovement();
            AddDrag();
            SpeedControl();
            SenseEnemy();
        }

    }

    // Get view direction from camera transform
    void GetViewDirection()
    {
        Vector3 camPosition = cam.transform.position;
        Vector3 playerPosition = transform.position;
        Vector3 viewDir = transform.position - new Vector3(camPosition.x, playerPosition.y, camPosition.z);
        orientation.forward = viewDir.normalized;
    }

    // Get Input direction using camera direction and input actions
    Vector3 GetInputDirection()
    {
        GetViewDirection();
        Vector2 inputVec = GetInputVector();
        return orientation.forward * inputVec.y + orientation.right * inputVec.x;
    }

    // Get input vector from input actions
    Vector2 GetInputVector()
    {
        Vector2 inputVector = playerInput.PlayerMain.Move.ReadValue<Vector2>();

        return inputVector;
    }

    // Add drag to physics
    void AddDrag()
    {
        if (isGrounded())
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    // Check if player is on the ground
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    // Reset jump state
    void ResetJump()
    {
        readyToJump = true;
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void SenseEnemy()
    {
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent<Agent>(out Agent agent))
            {

                //Debug.Log("overlap " + collider);
                transform.LookAt(agent.transform);
                //gunScript.shoot();
            }
        }
    }

    [Command]
    public void SpawnBullet()
    {
        --bulletCount;
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        NetworkServer.Spawn(bullet);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        //Debug.Log("Shoot");
        if (bulletCount > 0)
        {
            anim.SetBool("isShooting", true);
            if (isLocalPlayer)
                SpawnBullet();
        }
    }

    public void TakeHit(int damage)
    {
        health -= damage;
        Debug.Log("Health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
            //MainManager.Instance.PlayerDied();
        }
    }

    // Handle jump action
    public void Jump()
    {
        if (readyToJump && isGrounded())
        {
            readyToJump = false;
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump " + rb);
            Invoke(nameof(ResetJump), jumpCoolDown);
        }
    }

    // Move player in the moveDirection
    void MovePlayer(Vector3 moveDirection)
    {
        if (isGrounded())
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(moveDirection * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    // Update heading direction
    void UpdateMovement()
    {
        Vector3 inputDirection = GetInputDirection().normalized;
        if (inputDirection != Vector3.zero)
        {
            anim.SetBool("isShooting", false);
            MovePlayer(inputDirection);
            transform.forward = Vector3.Slerp(transform.forward, inputDirection, Time.deltaTime * rotationSpeed);
            anim.SetBool("isRunning", true);
            bluAnim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning", false);
            bluAnim.SetBool("isRunning", false);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<Agent>(out Agent agent))
        {
            //MainManager.Instance.GameOver();
        }

        if (other.gameObject.tag == "Deadzone")
        {
            //MainManager.Instance.GameOver();
        }
    }
}
