using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject ElevatorUI;
    public Transform defaultPosition;
    private Transform currentPosition;
    public Transform pointA;
    public Transform pointB;
    public Transform direction;
    public float LiftSpeed = 0.05f;

    void Start()
    {
        direction = defaultPosition;
        currentPosition = defaultPosition;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
            Activate();
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent = null;
            Deactivate();
        }
    }
    void Activate()
    {
        ElevatorUI.SetActive(true);
    }
    public void Upwards()
    {
        if (currentPosition.position != pointA.position)
            direction = pointA;
        Deactivate();
        return;
    }
    public void Default()
    {
        direction = defaultPosition;
        Deactivate();
    }
    public void Downards()
    {
        if (currentPosition.position != pointB.position)
            direction = pointB;
        Deactivate();
        return;
    }
    void Deactivate()
    {
        ElevatorUI.SetActive(false);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, direction.position, LiftSpeed);
    }
}
