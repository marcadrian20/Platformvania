using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerPosition : MonoBehaviour
{
    public TMP_Text positionText;
    public GameObject PositionUI;
    private Transform currentCheckpoint_;
    private void OnTriggerEnter2D(Collider2D collision)//whenever the player collides with the 'trigger'(box collider set as trigger)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpoint_ = collision.transform;//we save the checkpoint position and name
            ModifyText();
            StartCoroutine(TextShow());
        }
        if (collision.gameObject.CompareTag("Position"))
        {
            positionText.text = collision.transform.name;
            StartCoroutine(TextShow());
        }
    }
    private IEnumerator TextShow()
    {
        PositionUI.SetActive(true);//we activate and deactivate the Ui after some time
        yield return new WaitForSeconds(2.5f);//time for text on screen
        PositionUI.SetActive(false);
    }
    private void ModifyText()
    {
        positionText.text = currentCheckpoint_.name;//modify text based on the checkpoint name
    }

}
