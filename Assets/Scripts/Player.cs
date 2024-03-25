using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Movement _movement;
    public Input_Manager _inputManager;
    public bool isOnGround;

    public Rigidbody2D _rb;

    public LayerMask groundMask;

    void Start()
    {
        
    }

    void Update()
    {
        _inputManager.InputUpdate();
        //if (_inputManager.MovHorizontal != 0 )
        //{
        //    transform.position = _movement.MovementUpdate(_inputManager.MovHorizontal, _inputManager.Jump, Time.deltaTime, transform.position);
        //}

        _rb.velocity = new Vector2(_movement.VelX(_inputManager.MovHorizontal), _rb.velocity.y);

        //Set isOnGround
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1, groundMask);

        if (hit)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }


    private void FixedUpdate()
    {
        if (_inputManager.Jump && isOnGround)
        {
           _rb.AddForce(new Vector2(0, _movement.UseJump()), ForceMode2D.Impulse);
        }
        
    }
}
