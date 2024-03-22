using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;


    public Vector2 MovementUpdate(float movHorizontal, bool jump, float dt, Vector2 initialPosition)
    {
        Vector2 deltaMovement = initialPosition;
        deltaMovement.x = initialPosition.x + movHorizontal * speed * dt;
        //if (jump)
        //{
        //    deltaMovement.y = initialPosition.y + jumpForce * dt;
        //}
     
        return deltaMovement;
    }

    public float UseJump()
    {
        return jumpForce;
    }
}
