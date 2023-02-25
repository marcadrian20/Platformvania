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
    private Vector3 position;
    public float deathspeed = 3f;

    [Header("Potions")]
    [SerializeField]
    public List<GameObject> PotionSpawn = new List<GameObject>();
    void Start()
    {
        currentHealth = maxHealth;
        ani_name = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;//we save the name of idle anim

    }
    public void TakeDamage(int damage)
    {
        if (dead) return;
        currentHealth -= (Random.Range(-10, 10) + damage);
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0 && !dead)
        {
            StartCoroutine(Die());
            int itemIndex = Random.Range(0, PotionSpawn.Count), chance = Random.Range(0, 100);
            if (chance >= 50)
                Instantiate(PotionSpawn[itemIndex], position, Quaternion.identity);
        }
    }
    private IEnumerator Die()
    {
        position = transform.position;//death position  
        dead = true;//checking if dead or else its gonna loop the hurt animation when you hit despite the entity being dead
        GetComponent<SkellyAttack>().enabled = false;
        GetComponent<EnemyAI_Skelly>().enabled = false;
        animator.SetBool("IsDead", true);
        yield return new WaitForSecondsRealtime(deathspeed);
        gameObject.SetActive(false);// skelly for some fucking reason loves to snipe attack you beyond the grave
        yield return new WaitForSecondsRealtime(0.5f);
    }
    public void Respawn()
    {
        dead = false;
        currentHealth = maxHealth;
        animator.ResetTrigger("IsDead");
        animator.Play(ani_name);
        foreach (Behaviour component in components)
            component.enabled = true;//Activate all attached component classes

    }
}
//->Mark was here @furculita_in_priza