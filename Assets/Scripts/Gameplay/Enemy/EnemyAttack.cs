using UnityEngine;
using System.Collections;
using System;

public class EnemyAttack : MonoBehaviour
{
	public float timer = 2f;
    public int attackDamage = 10;
    public string animAttack = "Attack";
    public float Range = 2;
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
        enemyHealth = GetComponentInParent<EnemyHealth>();
		anim = GetComponentInParent <Animator> ();
    }

	void IsAtRange()
	{
		if (Vector3.Distance(this.transform.position, player.transform.position) <= Range)
			playerInRange = true;
		else
			playerInRange = false;
	}

    void FixedUpdate ()
    {

		IsAtRange ();
		if (!IsAttacking && playerInRange && enemyHealth.currentHealth > 0)
        {
            anim.SetTrigger(animAttack);
            StartCoroutine(Attack());
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }

	IEnumerator Attack ()
	{
	    //AudioManager.instance.Play("ZombieAttack");
	    IsAttacking = true;
	    yield return new WaitForSeconds (timer);
	    if (playerInRange)
		    playerHealth.TakeDamage (attackDamage);
	    yield return new WaitForSeconds (1f);
	    IsAttacking = false;
	}
}
