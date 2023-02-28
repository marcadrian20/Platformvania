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
        PlayerHealth.onDeath += gameover;//
    }                                   //
    void OnDisable()                    //===>We have to subscribe and unsubscribe to the onDeath events
    {                                   //     
        PlayerHealth.onDeath -= gameover;//
    }                                   //
    public void gameover()//temporary workaround because a coroutine cant subscribe to the event for some reason
    {
        StartCoroutine(GameOverSequence());
    }
    private IEnumerator GameOverSequence()//when called initiates the game over
    {
        yield return new WaitForSecondsRealtime(2f);
        Time.timeScale = 0f;//we wait a few seconds then we freeze the world time
        GameOverUI.SetActive(true);
    }
    public void Resume()//function used to resume after player hits the restart button
    {
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;//we reset the world time to its normalized speed
    }

    public void Restart()//on call respawns the player
    {
        Resume();
        playerRespawn.Respawn();
    }
    public void LoadMenu()//if the player used the menu button the scene is changed back to the Main Menu by decrementing the scene index
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Resume();//The time has to be set to normal otherwise everything is freezed
    }
}
