using UnityEngine;
using System.Collections;
using System;

public class EnemyAttack : MonoBehaviour
{
	public float timer = 2f;
    public int attackDamage = 10;

	float Range = 2;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
	Transform playerTransform;
	Transform myTransform;
    bool playerInRange;
	bool IsAttacking = false;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
		playerTransform = player.GetComponent<Transform> ();
        playerHealth = player.GetComponent <PlayerHealth> ();
		myTransform = this.GetComponent<Transform> ();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent <Animator> ();
		if (anim == null)
			anim = GetComponentInParent<Animator> ();
    }

	void IsAtRange()
	{
		if (Math.Sqrt ((Math.Pow (playerTransform.position.x - myTransform.position.x, 2) + (Math.Pow (playerTransform.position.z - myTransform.position.z, 2)))) <= Range)
			playerInRange = true;
		else
			playerInRange = false;
	}

    void FixedUpdate ()
    {

		IsAtRange ();
		if (!IsAttacking && playerInRange && enemyHealth.currentHealth > 0)
        {
			StartCoroutine(Attack());
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }

	IEnumerator Attack ()
	{
		if(playerHealth.currentHealth > 0)
		{
			anim.SetTrigger("Attack");
			IsAttacking = true;
			yield return new WaitForSeconds (timer);
			if (playerInRange)
				playerHealth.TakeDamage (attackDamage);
			yield return new WaitForSeconds (0.5f);
			IsAttacking = false;

		}
	}
}
