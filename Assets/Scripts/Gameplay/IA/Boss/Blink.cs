using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blink : MonoBehaviour {
    public float blinkTime;
    private float nextBlink;
    public float invTime;
    private float stopInv;
    public GameObject[] waypoints;
    private Transform position;
    public int waypointsId;
    private Renderer[] bossParts;
    private Canvas healthBar;
    private bool inv = false;
    private EnemyHealth health;
    private CapsuleCollider collider;
	public Boss1Attack1 attack;
	GameObject player;
	private EnemyMovement enemyMovement;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        position = GetComponent<Transform>();
        bossParts = GetComponentsInChildren<Renderer>();
		health = this.GetComponent<EnemyHealth>();
		enemyMovement = GetComponentInParent<EnemyMovement>();
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        collider = GetComponent<CapsuleCollider>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (health.isDead == true || !enemyMovement.GetAggro())
            return;
		
		if (Time.time > nextBlink && !attack.IsAttacking())
        {
            waypointsId = Random.Range(0, waypoints.Length); ;
            position.position = waypoints[waypointsId].transform.position;
            nextBlink = Time.time + blinkTime + invTime;
            stopInv = Time.time + invTime;
            foreach (Renderer test in bossParts)
            {
                test.enabled = false;
                collider.enabled = false;
            }
            inv = true;
        }
        if (Time.time > stopInv && inv == true)
        {
            foreach (Renderer test in bossParts)
            {
                collider.enabled = true;
                test.enabled = true;
            }
            inv = false;
        }
		Turning();
	}

    void Turning()
    {
        Vector3 playerToMouse = player.transform.position - transform.position;
        playerToMouse.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
        GetComponent<Rigidbody>().MoveRotation(newRotation);
    }

    public bool IsInv()
    {
        return inv;
    }
}
