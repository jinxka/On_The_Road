using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rage : MonoBehaviour {
    public float activateAt;
    public float speedBonus;
    public int damageBonus;
    private EnemyHealth enemyHealth;
    private EnemyAttack enemyAttack;
    private bool active = false;
    private UnityEngine.AI.NavMeshAgent nav;

    // Use this for initialization
    void Start () {
        enemyHealth = GetComponentInParent<EnemyHealth>();
        enemyAttack = GetComponent<EnemyAttack>();
        nav = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!active && enemyHealth.currentHealth <= activateAt)
        {
            active = true;
            enemyAttack.attackDamage += damageBonus;
            nav.speed += speedBonus;
        }
	}
}
