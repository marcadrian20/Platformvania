using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UltimateAnnounce : MonoBehaviour
{
    public GameObject UltimateUI;
    void OnEnable()
    {
        PlayerCombat.onUltReady += ShowUI;
    }

    void OnDisable()
    {
        PlayerCombat.onUltReady -= ShowUI;
    }
    public void ShowUI()
    {
        StartCoroutine(Show());
    }
    private IEnumerator Show()
    {
        UltimateUI.SetActive(true);
        //SoundManager.instance.PlaySound(checkpoint);
        yield return new WaitForSeconds(1f);//time for text on screen
        UltimateUI.SetActive(false);
    }
}
