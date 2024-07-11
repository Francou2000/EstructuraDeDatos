using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LS_PlayerMovement : MonoBehaviour
{
    private Animator m_Animator;

    [SerializeField] private DirecH directionH = DirecH.None;
    [SerializeField] private DirecV directionV = DirecV.None;

    public DirecH DirectionH { set { directionH = value; } }
    public DirecV DirectionV { set { directionV = value; } }

    public VerticesID actualVertice;
    private float verticeObjPosX;
    private float verticeObjPosY;

    public UnityEvent Arrived = new UnityEvent();
    private bool hasArrived = true;

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

                    if (transform.position.x > verticeObjPosX)
                    {
                        transform.position = new Vector2 (verticeObjPosX, transform.position.y);
                        directionH = DirecH.None;
                    }

                    break;
                case DirecH.Left:
                    m_Animator.SetBool("isRunning", true);
                    finalDirection.x = magnitude;
                    transform.rotation = Quaternion.Euler(0, 180, 0);

                    if (transform.position.x < verticeObjPosX)
                    {
                        transform.position = new Vector2(verticeObjPosX, transform.position.y);
                        directionH = DirecH.None;
                    }

                    break;
            }
            switch(directionV)
            {
                case DirecV.Up:
                    m_Animator.SetBool("isRunning", true);
                    finalDirection.y = magnitude;

                    if (transform.position.y > verticeObjPosY)
                    {
                        transform.position = new Vector2(transform.position.x, verticeObjPosY);
                        directionV = DirecV.None;
                    }

                    break;
                case DirecV.Down:
                    m_Animator.SetBool("isRunning", true);
                    finalDirection.y = -magnitude;

                    if (transform.position.y < verticeObjPosY)
                    {
                        transform.position = new Vector2(transform.position.x, verticeObjPosY);
                        directionV = DirecV.None;
                    }

                    break;
            }
            transform.Translate(finalDirection*5);
        }
        else
        {
            m_Animator.SetBool("isRunning", false);
            if (!hasArrived)
            {   
                hasArrived = true;
                Arrived.Invoke();
            }

        }
        
    }

    public void SetObjPosition(float posX, float posY)
    {
        verticeObjPosX = posX;
        verticeObjPosY = posY;
        hasArrived = false;

        if(verticeObjPosX > transform.position.x)
        {
            directionH = DirecH.Right;
        }
        else if (verticeObjPosX < transform.position.x)
        {
            directionH = DirecH.Left;
        }
        
        if(verticeObjPosY > transform.position.y)
        {
            directionV = DirecV.Up;
        }
        else if (verticeObjPosY < transform.position.y)
        {
            directionV = DirecV.Down;
        }


    }

    public void LoadScene()
    {
        StartCoroutine(EnterLevel());
    }

    public IEnumerator EnterLevel()
    {
        m_Animator.SetTrigger("NextLevel");
        yield return new WaitForSeconds(m_Animator.GetCurrentAnimatorStateInfo(0).length);
        switch (actualVertice)
        {
            case VerticesID.Level_0:
                SceneManager.LoadScene("MainMenu");
                break;
            case VerticesID.Level_1:
                SceneManager.LoadScene("Level_1");
                break;
            case VerticesID.Level_2:
                SceneManager.LoadScene("Level_2");
                break;
            case VerticesID.Level_3:
                SceneManager.LoadScene("Level_3");
                break;
            case VerticesID.Level_4:
                SceneManager.LoadScene("Level_4");
                break;
            case VerticesID.Level_5:
                SceneManager.LoadScene("Level_5");
                break;
            case VerticesID.Level_6:
                SceneManager.LoadScene("Boss");
                break;
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