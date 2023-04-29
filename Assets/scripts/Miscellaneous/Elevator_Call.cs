using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_Call : MonoBehaviour
{
    public Transform thisPoint;
    public Elevator elevator;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            elevator.direction = thisPoint;
        }
    }
}
