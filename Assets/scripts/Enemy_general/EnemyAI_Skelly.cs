using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;///we use the A* pathfinding algorithm in order to calculate the path and velocity 

public class EnemyAI_Skelly : MonoBehaviour
{
    Path path;
    public Transform target;
    public Transform SkellyGFX;
    Seeker seeker;
    Rigidbody2D rb;
    public Animator animator;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    private int currentWaypoint = 0;
    bool reachedEndOfPath;
    public bool facing_right = false;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0.5f, 0.5f);//We have to keep polling the UpdatePath so we can always track the player
    }
    void UpdatePath()
    {
        //if (seeker.IsDone()) For some god forsaken reason it doesnt work
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)//We check for completion and handle errors 
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void RandomAnimationGo()//Plays the "Move" animation
    {
        animator.SetBool("IsMoving", true);
    }
    void FixedUpdate()
    {
        if (path == null) return;
        if (currentWaypoint >= path.vectorPath.Count)
        {
            animator.SetBool("IsMoving", false);
            reachedEndOfPath = true;//useless variable,shit kinda breaks without it
            return;
        }
        else reachedEndOfPath = false;
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;     ///////We move the enemy towards the player after calculating the distance,force and direction to move in

        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;//we check for completion and increment if not close to the waypoint
        }
        if (rb.velocity.x >= 0.01f && force.x > 0f)//we handle the direction and we flip the sprite as needed
        {
            SkellyGFX.localScale = new Vector3(1f, 1f, 1f);
            RandomAnimationGo();
            facing_right = true;
        }
        else if (rb.velocity.x <= -0.01f && force.x < 0f)
        {
            SkellyGFX.localScale = new Vector3(-1f, 1f, 1f);
            RandomAnimationGo();
            facing_right = false;
        }
    }
}
//This horrible shit was done with the help of my dwindling sanity and random shit i saw on the a* docs
//Data bases aint looking too bad rn 