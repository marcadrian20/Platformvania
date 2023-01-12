using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemylayers;
    public int attackDamage = 40;
    public float attackRate = 3f;
    float nextAttackTime = 0f;

    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
            if (Input.GetButtonDown("Fire1"))
            {

                animator.SetTrigger("Attack");
                Invoke("Attack", 0.5f);
                // ();
                nextAttackTime = Time.time + 1f / attackRate;
            }
    }
    void Attack()
    {
        //play attack animation
        //detect enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemylayers);
        //Damage em
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<SkellyHealth>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackpoint == null) return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}
///Mark made <3