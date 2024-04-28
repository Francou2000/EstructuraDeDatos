using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public int enemiesOnLevelLeft;

    public static EnemyCounter Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Update()
    {
        if (enemiesOnLevelLeft == 0)
        {
            NextLevel();
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene("Level_2");
    }
}
