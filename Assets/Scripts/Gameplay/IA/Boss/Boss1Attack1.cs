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
    float timer;

    public Rigidbody bulletCasing = null;
    public int ejectSpeed = 25;

	bool isAttacking = false;
    Blink blink;
	private EnemyMovement enemyMovement;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponentInParent<EnemyHealth>();
        anim = GetComponentInParent<Animator>();
        blink = GetComponentInParent<Blink>();
		enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    void FixedUpdate()
	{
		if (!enemyMovement.GetAggro () || playerHealth.currentHealth <= 0) {
			isAttacking = false;
			return;
		}
		if (!isAttacking && !blink.IsInv() && enemyHealth.currentHealth > 0)
        {
			StartCoroutine(Attack());
        }

        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

	IEnumerator Attack()
	{
		isAttacking = true;
		pattern = Random.Range(0, 10)%2;
		if (pattern == 1){
			anim.SetTrigger("Attack01");
			yield return new WaitForSeconds (0.5f);
		}
		else{
			anim.SetTrigger("Attack02");
			yield return new WaitForSeconds (1);
		}
        if (playerHealth.currentHealth > 0)
        {
			while (bulletShot < bulletNbr) {
				
				shoot();
				bulletShot = bulletShot + 1;
				if (pattern == 1)
					yield return new WaitForSeconds(0.5F);
				if (playerHealth.currentHealth <= 0)
					yield break;
			}
		}
		bulletShot = 0;
		isAttacking = false;
		yield return new WaitForSeconds(0.5f);
    }

	public bool IsAttacking()
	{
		return isAttacking;
	}

    public void shoot()
    {
        Rigidbody bullet = null;
        bullet = Instantiate(bulletCasing);
        if (pattern == 0)
        {
            bullet.GetComponent<Script_Enemy_bullet>().setDmg(attackDamage);
            bullet.transform.rotation = transform.rotation;
            bullet.transform.position = transform.position;
            bullet.velocity = transform.TransformDirection(new Vector3(-0.30f + (bulletShot * 0.20f), 0, 1) * ejectSpeed);
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
