using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFirstBoss : MonoBehaviour {
    private EnemyHealth enemyHealth;
	// Use this for initialization
	void Start () {
        enemyHealth = GetComponent<EnemyHealth>();
    }

    void FixedUpdate () {
        if (enemyHealth.currentHealth <= 0)
        {
            SceneLoading.Instance.loadScene("Zone_Colonie_Safe");
            Destroy(this);
        }
    }
}
