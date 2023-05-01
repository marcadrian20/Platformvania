using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    void Update()//in the update function we handle the logic for the pause menu
    {
        if (Input.GetButtonDown("Cancel"))//when the pause button is pressed 
        {
            if (GameIsPaused)//we either unpause
                Resume();
            else Pause();//or pause
        }
    }
    public void Resume()//The game's speed is set back to normal and the visual element is disabled
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()//the pause function 
    {
        pauseMenuUI.SetActive(true);///works by activating an already existing UI element 
        Time.timeScale = 0.1f;//and either freezing the game's speed or just lowering it, depends on the desired effect; 
        GameIsPaused = true;
    }
    public void LoadMenu()//used to go back to the previous scene(main menu)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Resume();//We set the normal world speed for the next time we press play in the menu
    }///used as a workaround 
    public void QuitGame()
    {
        Application.Quit();//used to handle crashes and quiting the game
    }
}
