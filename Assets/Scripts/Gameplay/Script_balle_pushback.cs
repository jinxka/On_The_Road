using UnityEngine;
using System.Collections;

public class Script_balle_pushback : MonoBehaviour {
    public float bullet_LifeTime = 0.3F;
    public int damagePerShot = 5;

    private ParticleSystem hitParticles;
    private Collision ShootHit;
    private int shootableMask;

    // Use this for initialization
    void Start()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        hitParticles = GetComponentInChildren<ParticleSystem>();
        Destroy(gameObject, bullet_LifeTime);
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemies")
        {
            EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, col.gameObject.GetComponent<Rigidbody>().transform.position);
                Transform player = GameObject.FindGameObjectWithTag("Player").transform;
                Vector3 dir = col.transform.position - player.position;
                dir = dir.normalized;
                col.gameObject.GetComponent<Rigidbody>().AddForce(dir * 10000F);
            }
            Destroy(gameObject);
        }
    }
}
