using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public LayerMask collisionLayer;
    public float attackRate = 3f;
    float nextAttackTime = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.right, 5f, collisionLayer) || Physics2D.Raycast(transform.position, Vector2.left, 10f, collisionLayer))
        {
            if (Time.time >= nextAttackTime)
            {
                Shoot();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        Debug.DrawRay(transform.position, Vector3.right * 10f, Color.red);

    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}