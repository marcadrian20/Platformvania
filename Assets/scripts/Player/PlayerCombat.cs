using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;
public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public UltimateBar ultimateBar;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask enemylayers;
    public int attackDamage = 40;
    public int ultimateDamage = 100;
    public float attackRate = 3f;
    float nextAttackTime = 0f;
    public int next_ultimateTime = 100;
    public int ultimateTime = 1;
    public delegate void UltAction();
    public static event UltAction onUltReady;
    private bool CheckedForUlt = false;
    //[Header("Buff")]
    //public PoisonDebuff poisonDebuff;

    void Awake()
    {
        ultimateBar.UpdateUltimateBar();
    }
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                animator.SetTrigger("Attack");
                Invoke("Attack", 0.5f);
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetButtonDown("Fire2") && ultimateTime >= next_ultimateTime)
            {
                animator.SetTrigger("UltAtk");
                ultimateTime = 0;
                Invoke("Ultimate", 0.5f);
                ultimateBar.UpdateUltimateBar();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemylayers);
        //Damage em
        ultimateTime += Random.Range(0, 15);//stupid solution,works but if you spam attack it still raises.
        //shhh feature for speedrunners not bug
        ultimateBar.UpdateUltimateBar();
        //StartCoroutine(GetComponent<PlayerHealth>().Invunerability(.8f));
        UltimateReady();
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
        }

    }
    void UltimateReady()
    {
        if (ultimateTime >= next_ultimateTime && !CheckedForUlt)
        {
            CheckedForUlt = true;
            onUltReady();
        }

    }
    void Ultimate()
    {
        CheckedForUlt = false;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemylayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(ultimateDamage);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackpoint == null) return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}
///Mark made <3