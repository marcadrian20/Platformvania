using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkellyAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayer;
    public int attackDamage = 40;
    public float attackRate = 3f;
    float nextAttackTime = 0f;
    //void Update()
    //{
    /*if (Input.GetButtonDown("Fire1"))
    {
        Invoke("Attack", 0.5f);
    }*/
    //}
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit");
        if (Time.time >= nextAttackTime)
        {
            if (collision.gameObject)
            {
                animator.SetTrigger("Attack");
                InvokeRepeating("Attack", .7f, 1f);
            }
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, PlayerLayer);
        //Damage em
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackpoint == null) return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}
