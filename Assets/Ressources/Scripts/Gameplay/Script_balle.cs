using UnityEngine;
using System.Collections;

public class Script_balle : MonoBehaviour
{
    public float bullet_LifeTime = 3F;
    private int damagePerShot;

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
            Destroy(gameObject);
            EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, col.gameObject.GetComponent<Rigidbody>().transform.position);
            }
        }
    }

    public void setDmg(int dmg)
    {
        damagePerShot = dmg;
    }
}
