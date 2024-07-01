using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCounter : MonoBehaviour
{
    public int enemiesOnLevelLeft;
    public Player player;
    public static EnemyCounter Instance;

    private float timer = 0;

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
        timer += Time.deltaTime;
        if (enemiesOnLevelLeft == 0)
        {
            StartCoroutine(FinishLevel());
        }
    }

    private void NextLevel()
    {

        SceneManager.LoadScene("LevelSelection");
        GameManager.Instance.levelLock[2] = false;
        GameManager.Instance.levelLock[3] = false;

        GameManager.Instance.SetBestTimes((int)timer, VerticesID.Level_1);

    }

    private IEnumerator FinishLevel()
    {
        player.GetComponent<Input_Manager>().enabled = false;
        player.anim.SetTrigger("NextLevel");
        yield return new WaitForSeconds(player.anim.GetCurrentAnimatorStateInfo(0).length);
        NextLevel();
    }
}
