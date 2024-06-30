using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public bool[] levelLock = new bool[7];

    public Vector3[] bestTimes = new Vector3[7];
    public string[,] bestTimesNames = new string[7,3];

}
