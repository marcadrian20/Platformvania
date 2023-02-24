using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerRespawn : MonoBehaviour
{
    //[SerializeField] private AudioClip checkpoint;
    public Transform currentCheckpoint;
    private PlayerHealth playerHealth;
  

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void Respawn()
    {
        playerHealth.Respawn(); //Restore player health and reset animation
        transform.position = currentCheckpoint.position; //Move player to checkpoint location
        //Move the camera to the checkpoint's room
        //Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            playerHealth.AddHealth(40);
            //playerHealth.onDeath += Respawn;
            //SoundManager.instance.PlaySound(checkpoint);
            //collision.GetComponent<Collider2D>().enabled = false;
            //            collision.GetComponent<Animator>().SetTrigger("activate");
        }
    }
}
