using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;
    public bool dead = false;
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private string ani_name;
    public float deathspeed = 3f;

    //public HealthBar HealthBar;
    void Start()
    {
        currentHealth = maxHealth;
        ani_name = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;//we save the name of idle anim
        //HealthBar.SetMaxHealth(maxHealth);

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= (Random.Range(-10, 10) + damage);
        if (!dead) animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
            dead = true;//checking if dead or else its gonna loop the hurt animation when you hit despite the entity being dead
        }
        //Debug.Log("Text:" + ani_name);
        //HealthBar.SetHealth(currentHealth);
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
    public void Respawn()
    {
        dead = false;
        //AddHealth(maxHealth);
        currentHealth = maxHealth;
        animator.ResetTrigger("IsDead");
        animator.Play(ani_name);
        //Activate all attached component classes
        foreach (Behaviour component in components)
            component.enabled = true;

    }
}
//->Mark was here @furculita_in_priza