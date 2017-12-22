using UnityEngine;
using System.Collections;

public class Script_explosion : MonoBehaviour {
    public int damageExplosion = 100;
    public GameObject exploEffect;

	// Use this for initialization
	void Start () {
        GameObject test =  Instantiate(exploEffect, transform.position, transform.rotation);
        test.transform.parent = gameObject.transform;
        Destroy(gameObject, 1F);
    }
	
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemies")
        {
            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageExplosion, col.transform.position);
            }
        }
    }
}
