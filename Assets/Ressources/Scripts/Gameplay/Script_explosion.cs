using UnityEngine;
using System.Collections;

public class Script_explosion : MonoBehaviour {
    public float timer = 2F;
    public int damageExplosion = 100;

	// Use this for initialization
	void Start () {
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
