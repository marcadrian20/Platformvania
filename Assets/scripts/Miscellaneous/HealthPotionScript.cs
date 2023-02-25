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

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            HealthValue = Random.Range(10, 35);
            playerHealth = collision.GetComponent<PlayerHealth>();
            playerHealth.AddHealth(HealthValue);
        }
    }
}