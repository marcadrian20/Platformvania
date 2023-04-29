using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ControlsUI;
    public void PlayGame()
    {//we change the scene 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Options()
    {
        ControlsUI.SetActive(true);
    }
    public void CloseOP()
    {
        ControlsUI.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
