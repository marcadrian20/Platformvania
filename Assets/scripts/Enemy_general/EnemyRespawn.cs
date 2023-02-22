using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EnemyRespawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    private Health enemyHealth;
    Vector2 default_position;
  
    private void Awake()
    {
        enemyHealth = GetComponent<Health>();
        default_position = transform.position;//saves the spawn position
       
    }

    public void Respawn()
    {
        enemyHealth.Respawn(); //Restore health and reset animation
        transform.position = default_position; //Move to checkpoint location
        //onDeath();
    }
}
