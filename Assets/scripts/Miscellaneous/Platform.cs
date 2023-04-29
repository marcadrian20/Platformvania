using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private Transform currentPosition;
    public Transform pointA;
    public Transform pointB;
    public Transform direction;
    public float LiftSpeed;

    void Start()
    {
        direction = pointB;
        currentPosition = pointB;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.transform.parent = this.transform;
            Upwards();
        }
    }
    public void Upwards()
    {
        if (currentPosition.position != pointA.position)
        { direction = pointA; currentPosition = pointA; }
        else Downards();
    }
    public void Downards()
    {
        if (currentPosition.position != pointB.position)
        { direction = pointB; currentPosition = pointB; }
        return;
    }
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction.position, LiftSpeed);
    }
}
