using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using UnityEngine.UI;


public class VerticeData : MonoBehaviour
{
    public VerticesID myLevelName;
    public LS_GrafosController my_GrafosController;

    private Animator myAnimator;

    public GameObject playMenu;
    public Button playButton;
    public GameObject playButtonBlock;
    public GameObject leaderBoardBlock;
    public TextMeshProUGUI[] bestTimesText;
    private string[] bestTimes = new string[3];
    public bool isLoked;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.Instance;
        myAnimator = GetComponent<Animator>();
        isLoked = gameManager.levelLock[(int)myLevelName];
        bestTimes[0] = gameManager.bestTimesNames[(int)myLevelName, 0] + gameManager.bestTimes[(int)myLevelName].x;
        bestTimes[1] = gameManager.bestTimesNames[(int)myLevelName, 1] + gameManager.bestTimes[(int)myLevelName].y;
        bestTimes[2] = gameManager.bestTimesNames[(int)myLevelName, 2] + gameManager.bestTimes[(int)myLevelName].z;

    }


    public void SetVerticeAsObj()
    {
        my_GrafosController.MoveToVertice(myLevelName);
    }

    public void OpenPortal()
    {
        myAnimator.SetBool("IsOpen", true);
    }
    public void ClosePortal()
    {
        myAnimator.SetBool("IsOpen", false);
    }

    public void OpenPlayMenu()
    {
        playMenu.SetActive(true);
        if (isLoked)
        {
            playButtonBlock.SetActive(true);
            leaderBoardBlock.SetActive(true);
            playButton.enabled = false;
            for (int i = 0; i < 3; i++)
            {
                bestTimesText[i].text = "0";
            }
        }
        else
        {
            playButtonBlock.SetActive(false);
            leaderBoardBlock.SetActive(false);
            playButton.enabled = true;
            for (int i = 0; i < 3; i++)
            {
                bestTimesText[i].text = bestTimes[i];
            }
        }
        
    }

}

public enum VerticesID
{
    Level_0,
    Level_1,
    Level_2, 
    Level_3, 
    Level_4, 
    Level_5, 
    Level_6
}