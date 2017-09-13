﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Seeker))]
public class EnemyAI : MonoBehaviour
{
    // What to chase
    public Transform target;

    // How many times each second we will update our path
    public float updateRate = 2f;

    // Caching
    private Seeker seeker;
    private Rigidbody2D rb;

    // the calculated path
    public Path path;

    // The AI's speed per sec
    public float speed = 500f;
    public ForceMode2D fMode;

    [HideInInspector]
    public bool pathIsEnded = false;

    // The max distance from the AI to a waypoint for it to continue to the next waypoint
    public float nextWayPointDistance = 3;

    // the waypoint we are currently moving towards
    private int currentWayPoint = 0;

    private bool searchingForPlayer = false;

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        if (target == null)
        {
            if(!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }
        // Start a new path to the target position, return the result to the OnPathComplete method
        seeker.StartPath(transform.position, target.position, OnPathComplete);

        StartCoroutine(UpdatePath());
    }
    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;

            currentWayPoint = 0;
        }
    }

    IEnumerator SearchForPlayer()
    {
        GameObject result =  GameObject.FindGameObjectWithTag("Player");
        if (result == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        }
        else
        {
            target = result.transform;
            searchingForPlayer = false;
            StartCoroutine(UpdatePath());
        }
    }
    IEnumerator UpdatePath()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
        }
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        
        yield return new WaitForSeconds(1f / updateRate);
        StartCoroutine(UpdatePath());
    }
    void FixedUpdate()
    {
        if (target == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        // TODO: Always look at player?

        if (path == null)
        {
            return;
        }
        if (currentWayPoint >= path.vectorPath.Count)
        {
            if (pathIsEnded)
            {
                return;
            }
            //Debug.Log("End of path reached.");
            pathIsEnded = true;
            return;
        }
        StartCoroutine(SearchForPlayer());
        pathIsEnded = false;

        // Direction to the next waypoint
        Vector3 dir = (path.vectorPath[currentWayPoint] - transform.position).normalized;
        dir *= speed * Time.fixedDeltaTime;

        // Move the AI
        rb.AddForce(dir,fMode);
        float dist = Vector3.Distance(transform.position, path.vectorPath[currentWayPoint]);

        if (dist < nextWayPointDistance)
        {
            currentWayPoint++;
        }
    }
}
