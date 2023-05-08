using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.Events;
public class PlayerRespawn : NetworkBehaviour
{
    //[SerializeField] private AudioClip checkpoint;
    public Transform currentCheckpoint;
    private PlayerHealth playerHealth;
    public GameObject player;

    private void Awake()
    {
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    public void Respawn()
    {
        playerHealth.Respawn(); //Restore player health and reset animation
        transform.position = currentCheckpoint.position; //Move player to checkpoint location
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;//on collision we save the current checkpoint
            playerHealth.AddHealth(40);///as a reward we give the player health
        }
    }
}
