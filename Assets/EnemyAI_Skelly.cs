using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

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
    bool reachedEndOfPath;// = false;
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0.5f, 0.5f);//might modify later
    }
    void UpdatePath()
    {
        //if (seeker.IsDone()) For some god forsaken reason it doesnt work
        seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void RandomAnimationGo()
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
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
        //var speedFactor = reachedEndOfPath ? Mathf.Sqrt(distance / nextWaypointDistance) : 1f; //dont question me dunno why or how it works
        //found this thing in the documentation and it looked fancy,its hit or miss

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        if (rb.velocity.x >= 0.01f && force.x > 0f)
        {
            SkellyGFX.localScale = new Vector3(1f, 1f, 1f);
            RandomAnimationGo();
        }
        else if (rb.velocity.x <= -0.01f && force.x < 0f)
        {
            SkellyGFX.localScale = new Vector3(-1f, 1f, 1f);
            RandomAnimationGo();
        }
    }
}
//This horrible shit was done with the help of my dwindling sanity and random shit i saw on the a* docs
//Data bases aint looking too bad rn 