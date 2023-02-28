using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public Animator animator;
    public HealthBar HealthBar;
    private CharacterController2D characterController2D;
    private Rigidbody2D rigidbody2D;
    public int maxHealth = 100;
    public float iframe = 1.5f;
    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    [HideInInspector] public int currentHealth;
    public delegate void DeadAction();
    public static event DeadAction onDeath;
    public bool dead = false;
    private bool invulnerable = false;

    void Start()
    {
        characterController2D = GetComponent<CharacterController2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);

    }
    public void TakeDamage(int damage)
    {
        if (invulnerable || dead) return;
        if (characterController2D.m_FacingRight)
            rigidbody2D.AddForce(new Vector2(-200f, 100f));
        else rigidbody2D.AddForce(new Vector2(200f, 100f));

        currentHealth -= (Random.Range(-10, 10) + damage);
        HealthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            StartCoroutine(Die());
        }
        else if (!dead)
        {
            StartCoroutine(Invunerability(iframe));
            animator.SetTrigger("Hurt");
        }
    }
    public void AddHealth(int _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, maxHealth);
        HealthBar.SetHealth(currentHealth);
    }
    public void Respawn()
    {
        rigidbody2D.drag = 0f;
        dead = false;
        currentHealth = maxHealth;
        animator.ResetTrigger("IsDead");
        HealthBar.SetHealth(currentHealth);
        animator.Play("Player_idle");
        StartCoroutine(Invunerability(iframe));
        //Activate all attached component classes
        //GetComponent<CharacterController2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = true;
        foreach (Behaviour component in components)
            component.enabled = true;
    }
    public IEnumerator Die()
    {
        rigidbody2D.drag = 10f;
        dead = true;//checking if dead or else its gonna loop the hurt animation when you hit despite the entity being dead
        GetComponent<CharacterController2D>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        animator.SetBool("IsDead", true);
        animator.Play("Player_dead");
        yield return new WaitForSecondsRealtime(1f);
        onDeath();
        foreach (Behaviour component in components)
            component.enabled = false;
    }

    public IEnumerator Invunerability(float invtime)
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(8, 9, true);
        yield return new WaitForSecondsRealtime(invtime);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        invulnerable = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Crouch"))
            Die();
    }
}//edited,dont ask
 //->Mark was here @furculita_in_priza