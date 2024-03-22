using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Movement _movement;
    public Input_Manager _inputManager;
    public bool isOnGround;

    public Rigidbody2D _rb;

    void Start()
    {
        
    }

    void Update()
    {
        _inputManager.InputUpdate();
        if (_inputManager.MovHorizontal != 0 )
        {
            transform.position = _movement.MovementUpdate(_inputManager.MovHorizontal, _inputManager.Jump, Time.deltaTime, transform.position);
        }
        
        if (_rb.velocity.y != 0 ) 
        { 
            isOnGround = false;
        } 
        else
        {
            isOnGround = true;
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
