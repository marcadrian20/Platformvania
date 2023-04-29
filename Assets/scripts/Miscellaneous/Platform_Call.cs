using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Call : MonoBehaviour
{
    public Transform thisPoint;
    public Platform platform;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            platform.direction = thisPoint;
        }
    }
}
