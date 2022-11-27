using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemylayers;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }
    void Attack()
    {
        //play attack animation
        animator.SetTrigger("Attack");
        //detect enemy
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemylayers);
        //Damage em
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
        }
    }
    void OnDrawGizmosSelected(){
        Gizmos.DrawWireSphere(attackpoint.position,attackRange);
    }
}
