using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;


    public float MaxSpeed => maxSpeed;
    public float JumpForce => jumpForce;
}

