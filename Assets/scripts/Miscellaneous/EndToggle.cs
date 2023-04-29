using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndToggle : MonoBehaviour
{
    public GameObject EndUI;
    public GameObject part1;
    public GameObject part2;
    public GameObject part3;
    public GameObject part4;
    public GameObject part5;
    public GameObject part6;
    public GameObject part7;
    public PlayerMovement playerMovement;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            slowdown();
            EndUI.SetActive(true);
            StartCoroutine(CreditsRoll());
        }
    }
    private IEnumerator CreditsRoll()
    {
        yield return new WaitForSecondsRealtime(1.2f);
        part1.SetActive(true);
        yield return new WaitForSecondsRealtime(1.2f);
        part2.SetActive(true);
        yield return new WaitForSecondsRealtime(1.2f);
        part3.SetActive(true);
        yield return new WaitForSecondsRealtime(1.2f);
        part4.SetActive(true);
        yield return new WaitForSecondsRealtime(2f);
        part1.SetActive(false);
        part2.SetActive(false);
        part3.SetActive(false);
        part4.SetActive(false);
        yield return new WaitForSecondsRealtime(2f);
        part5.SetActive(true);
        yield return new WaitForSecondsRealtime(1.2f);
        part6.SetActive(true);
        yield return new WaitForSecondsRealtime(1.2f);
        part7.SetActive(true);

    }
    void slowdown()
    {
        Time.timeScale = 0.4f;
        //playerMovement.runSpeed = 10f;->looks too artificial
    }
}
