using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UltimateAnnounce : MonoBehaviour
{
    public GameObject UltimateUI;
    public GameObject UltimateIcon;
    void OnEnable()
    {
        PlayerCombat.onUltReady += ShowUI;
    }                                           //We use ondisable and on enable to subscribe to an event
    void OnDisable()                    //in this case the event tracks the Ultimate Skill and whenever it is ready  
    {
        PlayerCombat.onUltReady -= ShowUI;
    }                               
    public void ShowUI()//workaround for coroutines
    {
        StartCoroutine(Show());
    }
    private IEnumerator Show()//used to handle the ui
    {
        UltimateUI.SetActive(true);
        UltimateIcon.SetActive(true);
        yield return new WaitForSeconds(1f);//time for text on screen
        UltimateUI.SetActive(false);
    }
}
