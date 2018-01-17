using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCharge : MonoBehaviour {
    public int Degats = 5;
    private float slow = 3;
    private float slowDuration = 2;
    private GameObject player;
    public EnemyMovement enemyMovement;
    private bool isCharging = false;
    private bool isReady = false;
    public float movementSpeed = 30;
    private float chargeTimer = 0f;
    private float waitTimer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    void FixedUpdate()
    {
        if (enemyMovement.GetAggro())
        {
            Moving();
        }
    }

    void Moving()
    {
        if ((Time.time - chargeTimer < 1F) || isReady)
        {
            UseCharge();
        }
        else
        {
            Turning();
            isCharging = false;
            if ((Time.time - waitTimer) > 4F)
                isReady = true;
        }
    }

    void Turning()
    {
        Vector3 playerToMouse = player.transform.position - transform.position;
        playerToMouse.y = 0f;

        Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
        GetComponent<Rigidbody>().MoveRotation(newRotation);
    }

    void UseCharge()
    {
        if (isCharging)
            waitTimer = Time.time;
        else
            chargeTimer = Time.time;
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
        isCharging = true;
        isReady = false;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && enemyMovement.GetAggro())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Degats);
            collision.gameObject.GetComponent<PlayerMovement>().Slow(slow, slowDuration);
        }
    }
}
