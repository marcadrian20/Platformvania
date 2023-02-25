using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    [HideInInspector] public int currentHealth;
    public delegate void DeadAction();
    public static event DeadAction onDeath;
    public bool dead = false;
    public float deathspeed = 3f;
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    private bool invulnerable;
    public HealthBar HealthBar;



    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);

    }
    public void TakeDamage(int damage)
    {
        if (invulnerable) return;
        currentHealth -= (Random.Range(-10, 10) + damage);
        if (!dead)
        {
            StartCoroutine(Invunerability());
            animator.SetTrigger("Hurt");
        }
        if (currentHealth <= 0)
        {
            Die();
            dead = true;//checking if dead or else its gonna loop the hurt animation when you hit despite the entity being dead
            foreach (Behaviour component in components)
                component.enabled = false;
        }
        HealthBar.SetHealth(currentHealth);
    }
    public void AddHealth(int _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, maxHealth);
        HealthBar.SetHealth(currentHealth);
    }
    public void Respawn()
    {
        dead = false;
        //AddHealth(maxHealth);
        currentHealth = maxHealth;
        animator.ResetTrigger("IsDead");
        HealthBar.SetHealth(currentHealth);
        animator.Play("Player_idle");
        StartCoroutine(Invunerability());

        //Activate all attached component classes
        foreach (Behaviour component in components)
            component.enabled = true;
    }
    void Die()
    {
        GetComponent<CharacterController2D>().enabled = false; //never do this its plain stupid im retarded
        animator.SetBool("IsDead", true);
        onDeath();
        //Invoke("Dissapear", deathspeed);//disable enemy
    }
    void Dissapear()
    {
        gameObject.SetActive(false);
    }
    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSecondsRealtime(1.5f);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        invulnerable = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Crouch"))
            TakeDamage(40);
    }
}//edited,dont ask
 //->Mark was here @furculita_in_priza