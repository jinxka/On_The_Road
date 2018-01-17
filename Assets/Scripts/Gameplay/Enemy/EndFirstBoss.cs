using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFirstBoss : MonoBehaviour {
    public GameObject colonie;
    private EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () {
        enemyHealth = GetComponent<EnemyHealth>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (enemyHealth.currentHealth <= 0)
            colonie.SetActive(true);
    }
}
