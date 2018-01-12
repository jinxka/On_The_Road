using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjMovement : MonoBehaviour {
    Animator anim;
    UnityEngine.AI.NavMeshAgent nav;
    public string animRun;
    public GameObject[] waypoints;
    public int waypointsId;

    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        anim.SetBool(animRun, true);
        Patrol();
    }

    void FixedUpdate()
    {
        StartCoroutine("Moving");
    }

    IEnumerator Moving ()
    {
        if (Vector3.Distance (this.transform.position, waypoints[waypointsId].transform.position) >= 2)
        {
            return null;
        }
        else
        {
            Patrol();
        }
        return null;
    }

    void Patrol ()
    {
        nav.updatePosition = true;
        waypointsId = Random.Range(0, waypoints.Length);
        nav.SetDestination(waypoints[waypointsId].transform.position);
    }
}
