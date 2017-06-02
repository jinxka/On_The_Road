using UnityEngine;
using System.Collections;

public class Script_grenade : MonoBehaviour
{
    public float grenade_LifeTime = 3F;
    public GameObject Explosion;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Timer_Explosion");
    }

    void Explose()
    {
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator Timer_Explosion()
    {
        yield return new WaitForSeconds(grenade_LifeTime);
        Explose();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemies")
        {
            Explose();
        }
    }
}
