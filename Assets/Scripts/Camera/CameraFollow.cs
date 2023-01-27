using UnityEngine;
using Mirror;
public class CameraFollow : NetworkBehaviour
{
    Camera mainCam;

    public float smoothSpeed = 1.0f;
    public Vector3 offset;

    private void Start()
    {
        mainCam = Camera.main;
    }
    private void LateUpdate()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        mainCam.transform.position = transform.position + offset;

        //Vector3 smoothedPosition = Vector3.Lerp(mainCam.transform.position, desiredPosition, smoothSpeed);
        //mainCam.transform.position = smoothedPosition;
        //mainCam.transform.LookAt(transform);

    }
}
