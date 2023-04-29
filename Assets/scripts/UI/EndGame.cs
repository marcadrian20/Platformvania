using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGame : MonoBehaviour
{
    public GameObject GameEndUI;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(GameEndingSequence());
        }
    }
    private IEnumerator GameEndingSequence()
    {
        yield return new WaitForSecondsRealtime(2f);
        GameEndUI.SetActive(false);
        yield return new WaitForSecondsRealtime(5f);
        LoadMenu();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1f;
    }
}
