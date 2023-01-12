using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public bool dead = false;
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
            dead = true;
        }
    }
    void Die()
    {
        animator.SetBool("IsDead", true);
        //GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Invoke("Dissapear", 3f);//disable enemy
    }
    void Dissapear()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
