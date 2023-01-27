using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Bullet : NetworkBehaviour
{
    int bulletLife = 3;
    public int bulletDamage = 10;

    [SerializeField] string type;

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }

    [ServerCallback]
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter enter on bullet.cs");
        Destroy(gameObject);
        NetworkServer.Destroy(gameObject);
        /*
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (type != "player")
            {
                player.TakeHit(bulletDamage);
            }
        }
        else if (other.gameObject.TryGetComponent<Agent>(out Agent agent))
        {
            agent.TakeHit(bulletDamage);
        }
        */
    }


    /*
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (type != "player")
            {
                player.TakeHit(bulletDamage);
            }
        }
        else if (other.gameObject.TryGetComponent<Agent>(out Agent agent))
        {
            //agent.TakeHit(bulletDamage);
        }
    }
    */
}
