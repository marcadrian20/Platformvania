using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Animator animator;
    [SerializeField]
    private GameObject spiderBullet;

    [SerializeField]
    private Transform bulletSpawnPos;

    [SerializeField]
    private float minShootWaitTime = 1f, maxShootWaitTime = 3f;

    private float waitTime;

    [SerializeField]
    private List<GameObject> bullets;

    private bool canShoot;
    private int bulletIndex;

    [SerializeField]
    private int initialBulletCount = 2;

    private void Start()
    {
        for (int i = 0; i < initialBulletCount; i++)
        {
            bullets.Add(Instantiate(spiderBullet));
            bullets[i].SetActive(false);
        }
    }

    void Shoot()
    {
        canShoot = true;
        bulletIndex = 0;

        while (canShoot)
        {
            if (!bullets[bulletIndex].activeInHierarchy)
            {
                bullets[bulletIndex].SetActive(true);
                bullets[bulletIndex].transform.position = bulletSpawnPos.position;

                canShoot = false;
            }
            else
            {
                bulletIndex++;
            }

            if (bulletIndex == bullets.Count)
            {

                bullets.Add(Instantiate(spiderBullet, bulletSpawnPos.position, Quaternion.identity));

                canShoot = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
            Invoke("Shoot", .5f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Time.time > waitTime)
            {
                animator.SetTrigger("Attack");
                waitTime = Time.time + Random.Range(minShootWaitTime, maxShootWaitTime);
                Invoke("Shoot", .5f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Attack");
            Invoke("Shoot", .5f);
        }
    }

}