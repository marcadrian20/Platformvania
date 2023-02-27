using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjects;

public class SkellyAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public float attackRange = 0.5f;
    public LayerMask PlayerLayer;
    public int attackDamage = 40;
    public float attackRate = 3f;
    [Header("Debuffs")]
    [SerializeField]
    public List<ScriptableBuff> DebuffSpawn = new List<ScriptableBuff>();
    float nextAttackTime = 0f;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= nextAttackTime)
            {
                animator.SetTrigger("Attack");
                Attack();
                Debuff(collision.gameObject);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Debuff(GameObject target)
    {
        int DebuffChance = Random.Range(0, 100);
        int itemIndex = Random.Range(0, DebuffSpawn.Count);
        if (DebuffChance >= 75)
            target.GetComponent<BuffableEntity>().AddBuff(DebuffSpawn[itemIndex].InitializeBuff(target));
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, PlayerLayer);
        //Damage em
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }

    }
    void OnDrawGizmosSelected()
    {
        if (attackpoint == null) return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}
