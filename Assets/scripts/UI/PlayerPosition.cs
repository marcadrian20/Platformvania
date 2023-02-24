using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerPosition : MonoBehaviour
{
    public TMP_Text positionText;
    public GameObject PositionUI;
    private Transform currentCheckpoint_;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpoint_ = collision.transform;//we save the checkpoint position and name
            ModifyText();
            StartCoroutine(TextShow());
        }
    }
    private IEnumerator TextShow()
    {
        PositionUI.SetActive(true);
        //SoundManager.instance.PlaySound(checkpoint);
        yield return new WaitForSeconds(2.5f);//time for text on screen
        PositionUI.SetActive(false);
    }
    private void ModifyText()
    {
        positionText.text = currentCheckpoint_.name;//modify text based on the checkpoint name
    }

}
