using UnityEngine;
using System.Collections;

public class EnemyRangedAttack : MonoBehaviour {
    public float timeBetweenAttacks = 10f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    EnemyRangedMovement enemyRangedMovement;
    bool playerInRange = false;
    bool retreat = false;
    bool melee = false;
    float timer;

    public Rigidbody bulletCasing = null;
    public int ejectSpeed = 25;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
        enemyRangedMovement = GetComponentInParent<EnemyRangedMovement>();
        anim = GetComponentInParent<Animator>();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        playerInRange = enemyRangedMovement.getPlayerInRange();
        retreat = enemyRangedMovement.getRetreat();
        melee = enemyRangedMovement.getIsMelee();
        if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0 && !retreat)
        {
           Attack();
        }

        if (!playerInRange || retreat)
        {
            timer = 0;
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            anim.SetTrigger("Attack");
            shoot();
        }
    }

    public void shoot()
    {/*


        gunAudio.Play();
        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play();*/
        Rigidbody bullet = null;

        bullet = Instantiate(bulletCasing);
        bullet.GetComponent<Script_Enemy_bullet>().setDmg(attackDamage);
        bullet.transform.rotation = transform.rotation;
        bullet.transform.position = transform.position;
        bullet.velocity = transform.TransformDirection(Vector3.forward * ejectSpeed);
    }
}
