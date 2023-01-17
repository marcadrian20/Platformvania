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

    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (!dead) animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
            dead = true;
        }
        healthBar.SetHealth(currentHealth);
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        Invoke("Dissapear", deathspeed);//disable enemy
    }
    void Dissapear()
    {
        gameObject.SetActive(false);

    }
}
