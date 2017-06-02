using UnityEngine;
using System.Collections;

public class Boss1Attack1 : MonoBehaviour {
    public float timeBetweenAttacks = 10f;
    public int attackDamage = 10;
    public int bulletNbr = 5;
    private int bulletShot = 0;
    private float nextBullet = 0;
    private int pattern = 0;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    EnemyRangedMovement enemyRangedMovement;
    float timer;

    public Rigidbody bulletCasing = null;
    public int ejectSpeed = 25;

    Blink blink;

    private bool inv;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
        enemyRangedMovement = GetComponentInParent<EnemyRangedMovement>();
        anim = GetComponentInParent<Animator>();
        blink = GetComponentInParent<Blink>();
    }

    void Update()
    {
        inv = blink.IsInv();
        timer += Time.deltaTime;
        if (timer >= timeBetweenAttacks && enemyHealth.currentHealth > 0 && inv != true || (bulletShot < bulletNbr && bulletShot != 0))
        {
            if (Time.time > nextBullet)
            {
                Attack();
                if (pattern == 0)
                    nextBullet = Time.time;
                if (pattern == 1)
                    nextBullet = Time.time + 0.20f;
                bulletShot = bulletShot + 1;
            }
        }

        if (bulletShot == bulletNbr)
        {
            bulletShot = 0;
            pattern = Random.Range(0, 10)%2;
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
        if (pattern == 0)
        {
            bullet.GetComponent<Script_Enemy_bullet>().setDmg(attackDamage);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = transform.position;
            bullet.velocity = transform.TransformDirection(new Vector3(-0.30f + (bulletShot * 0.15f), 0, 1) * ejectSpeed);
        }
        if (pattern == 1)
        {
            bullet.GetComponent<Script_Enemy_bullet>().setDmg(attackDamage);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = transform.position;
            bullet.velocity = transform.TransformDirection(Vector3.forward * ejectSpeed);
        }
    }
}
