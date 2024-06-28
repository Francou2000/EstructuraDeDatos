using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_PlayerMovement : MonoBehaviour
{
    private Animator m_Animator;

    [SerializeField] private DirecH directionH = DirecH.None;
    [SerializeField] private DirecV directionV = DirecV.None;

    public DirecH DirectionH { set { directionH = value; } }
    public DirecV DirectionV { set { directionV = value; } }

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (directionH != DirecH.None || directionV != DirecV.None)
        {
            Vector2 finalDirection = Vector2.zero;
            float magnitude = Time.deltaTime;
            switch (directionH)
            {
                case DirecH.Right:
                    m_Animator.SetBool("isRunning", true);
                    finalDirection.x = magnitude;
                    transform.rotation = Quaternion.Euler(0,0,0);
                    break;
                case DirecH.Left:
                    m_Animator.SetBool("isRunning", true);
                    finalDirection.x = magnitude;
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
            }
            switch(directionV)
            {
                case DirecV.Up:
                    m_Animator.SetBool("isRunning", true);
                    finalDirection.y = magnitude;
                    break;
                case DirecV.Down:
                    m_Animator.SetBool("isRunning", true);
                    finalDirection.y = -magnitude;
                    break;
            }
            transform.Translate(finalDirection);
        }
        else
        {
            m_Animator.SetBool("isRunning", false);
        }
        
    }
}

public enum DirecH
{
    Right,
    Left,
    None
}

public enum DirecV
{
    Up,
    Down,
    None
}