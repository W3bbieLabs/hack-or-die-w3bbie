using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerBall : MonoBehaviour
{
    public Rigidbody soccerBallRigidbody;

    void Start()
    {
        soccerBallRigidbody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LocalPlayer")
        {
            soccerBallRigidbody.AddForce(collision.impulse, ForceMode.Impulse);
        }
    }
}

