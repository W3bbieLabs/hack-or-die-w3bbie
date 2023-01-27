using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;
    public float rotationSpeed = 7f;
    private PlayerInputActions playerInputActions;

    private EnemyDetection enemyDetectionScript;



    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.PlayerMain.Enable();
        enemyDetectionScript = GameObject.FindGameObjectWithTag("Player").GetComponent<EnemyDetection>();
    }

    private void FixedUpdate()
    {

        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;



        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");

        Vector2 inputVector = playerInputActions.PlayerMain.Move.ReadValue<Vector2>();



        Vector3 inputDir = orientation.forward * inputVector.y + orientation.right * inputVector.x;
        if (inputDir != Vector3.zero)
        {
            player.forward = Vector3.Slerp(player.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
*/
