using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsUI : MonoBehaviour
{
    public List<GameObject> StatsList = new List<GameObject>();
    public void ActivateBuff(int index)
    {
        StatsList[index].SetActive(true);
    }
    public void DeactivateBuff(int index)
    {
        StatsList[index].SetActive(false);
    }
}
