using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject player;
    private PlayerRespawn playerRespawn;
    private void Awake()
    {
        playerRespawn = player.GetComponent<PlayerRespawn>();
    }
    void OnEnable()
    {
        PlayerHealth.onDeath += gameover;
    }

    void OnDisable()
    {
        PlayerHealth.onDeath -= gameover;
    }
    public void gameover()
    {
        StartCoroutine(GameOverSequence());
    }
    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 0f;
        GameOverUI.SetActive(true);
    }
    public void Resume()
    {
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        playerRespawn.Respawn();
        Resume();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Resume();
    }
}
