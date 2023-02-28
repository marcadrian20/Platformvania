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
    public List<ScriptableBuff> DebuffSpawn = new List<ScriptableBuff>();//list to store debuffs/buffs
    float nextAttackTime = 0f;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= nextAttackTime)//on collision we check if the attack rate cooldown is over
            {//if so we attack and calculate the next time we can hit
                animator.SetTrigger("Attack");
                Attack();
                Debuff(collision.gameObject);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Debuff(GameObject target)//used to handle debuffs 
    {
        int DebuffChance = Random.Range(0, 100);//calculates the chance to apply a debuff
        int itemIndex = Random.Range(0, DebuffSpawn.Count);///and then the position of the effect in the debuff list
        if (DebuffChance >= 95)
            target.GetComponent<BuffableEntity>().AddBuff(DebuffSpawn[itemIndex].InitializeBuff(target));//We apply the effect on the target gameobject(usually the player)
    }

    void Attack()
    {
        if (GetComponent<Health>().dead) return;
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, PlayerLayer);//we make a list with the enemies inside the attack range 
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerHealth>().TakeDamage(attackDamage);//and as long as they are in the attack range we damage them
        }

    }
    void OnDrawGizmosSelected()//function used to draw small indication of the attack range in the unity editor
    {
        if (attackpoint == null) return;
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}
