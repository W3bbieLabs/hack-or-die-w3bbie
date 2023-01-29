using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public abstract class Unit : NetworkBehaviour
{
    [Header("Movement")]
    [SerializeField] protected float moveSpeed = 10f;
    [SerializeField] protected float groundDrag = 5f;
    protected float jumpForce = 12f;
    protected float jumpCoolDown = 0.25f;
    protected float airMultiplier = 0.4f;
    protected int health = 100;

    [Header("Sensing")]

    [SerializeField] protected float detectionRange = 1f;

}
