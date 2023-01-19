using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public bool dead = false;
    public float deathspeed = 3f;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (!dead) animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
            dead = true;//checking if dead or else its gonna loop the hurt animation when you hit despite the entity being dead
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        Invoke("Dissapear", deathspeed);//disable enemy
    }
    void Dissapear()
    {
        gameObject.SetActive(false);// skelly for some fucking reason loves to snipe attack you beyond the grave
        //Destroy(gameObject);///so destroy works for now ig
    }
}
//->Mark was here @furculita_in_priza