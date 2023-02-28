using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

public class HealthPotionScript : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private int HealthValue;

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))//on collision with the player
        {
            Destroy(gameObject);// we destroy the potion and apply the effects
            HealthValue = Random.Range(10, 35);//we calculate a random value to add to the current health
            playerHealth = collision.GetComponent<PlayerHealth>();
            playerHealth.AddHealth(HealthValue);//we handle the addition command
        }
    }
}