using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Movement _movement;
    public Input_Manager _inputManager;
    public bool isOnGround;
    public Rigidbody2D _rb;
    public LayerMask groundMask;

    private Animator anim;

    private Weapon _weapon;

    void Start()
    {
        anim = GetComponent<Animator>();
        _weapon = GetComponent<Weapon>();
    }

    void Update()
    {
        _inputManager.InputUpdate();

        if (_inputManager.Shoot)
        {
            _weapon.Shoot(transform.localScale.x/Mathf.Abs(transform.localScale.x), anim);
            
        }
        if (_inputManager.Recharge)
        {
            _weapon.Recharge();
        }

        var escalaX = transform.localScale.x;
        var escalaY = transform.localScale.y;
        if (_inputManager.MovHorizontal < 0 && escalaX > 0)
        {
            transform.localScale = new Vector3(-escalaX, escalaY, 1);
        }
        else if (_inputManager.MovHorizontal > 0 && escalaX < 0)
        {
            transform.localScale = new Vector3(-escalaX, escalaY, 1);
        }

        //Set isOnGround
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1, groundMask);

        if (hit)
        {
            isOnGround = true;
            anim.SetBool("isJumping", false);
            anim.SetTrigger("IsOnGround");
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
           _rb.AddForce(new Vector2(0, _movement.JumpForce), ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            
        }

        if (!isOnGround && _rb.velocity.y < 0)
        {
            anim.SetTrigger("Fall");
        }

        if (_inputManager.MovHorizontal != 0)
        {
            _rb.velocity = new Vector2(_movement.MaxSpeed * _inputManager.MovHorizontal, _rb.velocity.y);
            anim.SetBool("isRunning", true);
        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            anim.SetBool("isRunning", false);
            
        }


        
    }
}
