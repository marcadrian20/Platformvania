using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsUI : MonoBehaviour
{
    public List<GameObject> StatsList = new List<GameObject>();//we make a list of all the 
    public void ActivateBuff(int index)                         //stat effects
    {
        StatsList[index].SetActive(true);///then we activate/deactivate it as needed from another script
    }
    public void DeactivateBuff(int index)
    {
        StatsList[index].SetActive(false);
    }
}
