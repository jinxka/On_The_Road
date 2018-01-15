using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SuicideAttack : MonoBehaviour {

    float Range = 2;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    Transform playerTransform;
    Transform myTransform;
    bool playerInRange;
    bool IsAttacking = false;
    public GameObject Explosion;
    public GameObject parent;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        playerHealth = player.GetComponent<PlayerHealth>();
        myTransform = this.GetComponent<Transform>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
        anim = GetComponentInParent<Animator>();
    }

    void IsAtRange()
    {
        if (Math.Sqrt((Math.Pow(playerTransform.position.x - myTransform.position.x, 2) + (Math.Pow(playerTransform.position.z - myTransform.position.z, 2)))) <= Range)
            playerInRange = true;
        else
            playerInRange = false;
    }

    void Explose()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(parent);
    }

    void FixedUpdate()
    {

        IsAtRange();
        if ((!IsAttacking && playerInRange) || enemyHealth.currentHealth <= 0)
        {
            Explose();
			AudioManager.instance.Play("GrenadeExplosion");
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }
}
