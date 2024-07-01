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
        int[] myBestTimes = new int[3];
        myBestTimes[0] = gameManager.bestTimes[(int)myLevelName,0];
        myBestTimes[1] = gameManager.bestTimes[(int)myLevelName,1];
        myBestTimes[2] = gameManager.bestTimes[(int)myLevelName,2];

        if (myBestTimes[0] == int.MaxValue)
        {
            bestTimes[0] = string.Format("{0:00000}   {1:000}", gameManager.bestTimesNames[(int)myLevelName, 0], 0);
        }
        else
        {
            bestTimes[0] = string.Format("{0:00000}   {1:000}", gameManager.bestTimesNames[(int)myLevelName, 0], myBestTimes[0]);
        }

        if (myBestTimes[1] == int.MaxValue)
        {
            bestTimes[1] = string.Format("{0:00000}   {1:000}", gameManager.bestTimesNames[(int)myLevelName, 1], 0);
        }
        else
        {
            bestTimes[1] = string.Format("{0:00000}   {1:000}", gameManager.bestTimesNames[(int)myLevelName, 1], myBestTimes[1]);
        }

        if (myBestTimes[2] == int.MaxValue)
        {
            bestTimes[2] = string.Format("{0:00000}   {1:000}", gameManager.bestTimesNames[(int)myLevelName, 2], 0);
        }
        else
        {
            bestTimes[2] = string.Format("{0:00000}   {1:000}", gameManager.bestTimesNames[(int)myLevelName, 2], myBestTimes[2]);
        }
        
        
        

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