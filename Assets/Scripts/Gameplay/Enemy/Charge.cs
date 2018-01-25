using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour {
    public int Degats = 30;
    private Animator anim;
    private UnityEngine.AI.NavMeshAgent nav;
    public string animRun;
    private GameObject player;
    private EnemyMovement enemyMovement;
    private bool isCharging = false;
    private bool isReady = false;
    public float movementSpeed = 30;
    private float chargeTimer = 0f;
    private float waitTimer = 0f;

    void Start()
    {
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyMovement = GetComponent<EnemyMovement>();
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
            anim.SetBool(animRun, false);
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
		AudioManager.instance.Play("CreatureCharge");
        anim.SetBool(animRun, true);
        transform.position += transform.forward * Time.deltaTime * movementSpeed;
        isCharging = true;
        isReady = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isCharging && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(Degats);
        }
    }
}
