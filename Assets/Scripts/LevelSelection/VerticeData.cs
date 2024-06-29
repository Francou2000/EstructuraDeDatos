using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticeData : MonoBehaviour
{
    public VerticesID myLevelName;

    public LS_GrafosController my_GrafosController;

    public void SetVerticeAsObj()
    {
        my_GrafosController.MoveToVertice(myLevelName);
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