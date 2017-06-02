using UnityEngine;
using System.Collections;

public class AOE : MonoBehaviour {
    public float timer = 1F;
    public int damageAOE = 100;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, timer);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
            EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAOE, col.transform.position);
            }
        }
        Destroy(gameObject);
    }
}
