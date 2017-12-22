using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideExplosion : MonoBehaviour {
    public int damageExplosion = 30;
    public GameObject exploEffect;

    // Use this for initialization
    void Start()
    {
        GameObject test = Instantiate(exploEffect, transform.position, transform.rotation);
        test.transform.parent = gameObject.transform;
        Destroy(gameObject, 1F);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHealth playerHealth = col.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageExplosion);
            }
        }
    }
}
