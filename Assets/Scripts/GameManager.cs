using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Sort mySortTool = new Sort();

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
            for (int i = 0; i < 7; i++)
            {
                bestTimes[i, 0] = int.MaxValue;
                bestTimes[i, 1] = int.MaxValue;
                bestTimes[i, 2] = int.MaxValue;

                bestTimesNames[i, 0] = "None";
                bestTimesNames[i, 1] = "None";
                bestTimesNames[i, 2] = "None";
            }
            SetBestTimes(5, "El", VerticesID.Level_1);
            SetBestTimes(2, "Ele", VerticesID.Level_1);
        }
    }

    public bool[] levelLock = new bool[7];

    public int[,] bestTimes = new int[7,3];
    public string[,] bestTimesNames = new string[7,3];


    public void SetBestTimes(int time, string name, VerticesID levelName)
    {
        int[] times = { bestTimes[(int)levelName, 0], bestTimes[(int)levelName, 1], bestTimes[(int)levelName, 2], time};
        times = mySortTool.QuickSort(times, 0, times.Length - 1);

        bestTimes[(int)levelName, 0] = times[0];
        bestTimes[(int)levelName, 1] = times[1];
        bestTimes[(int)levelName, 2] = times[2];

        for (int i = 0; i < 3; i++)
        {
            if (times[i] == time)
            {
                for (int j = 2; j > i; j--)
                {
                    bestTimesNames[(int)levelName, j] = bestTimesNames[(int)levelName, j - 1];
                }
                bestTimesNames[(int)levelName, i] = name;
            }
        }
    }

}
