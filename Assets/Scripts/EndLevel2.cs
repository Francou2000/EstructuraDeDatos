using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel2 : MonoBehaviour
{
    float timer = 0;
    public Player player;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FinishLevel());
        }
    }

    private void NextLevel()
    {

        SceneManager.LoadScene("LevelSelection");

        GameManager.Instance.SetBestTimes((int)timer, VerticesID.Level_2);

    }

    private IEnumerator FinishLevel()
    {
        player.GetComponent<Input_Manager>().enabled = false;
        player.anim.SetTrigger("NextLevel");
        yield return new WaitForSeconds(player.anim.GetCurrentAnimatorStateInfo(0).length);
        NextLevel();
    }
}
