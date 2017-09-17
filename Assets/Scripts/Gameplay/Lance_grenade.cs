using UnityEngine;
using System.Collections;

public class Lance_grenade : MonoBehaviour {
    public Rigidbody grenadeCasing = null;
    public int ejectSpeed = 100;
    public float fireRate = 1F;

    private float nextFire = 0.0F;

    //Grenades
    public int grenade;
    public int grenadeMax = 3;

    void Awake()
    {

    }

    // Use this for initialization
    void Start ()
    {
        grenade = grenadeMax;
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
            if (grenade >= 1)
            {
                shoot_Grenade();
                grenade = grenade - 1;
            }
        }
    }

    public void shoot_Grenade()
    {
        /*
        gunAudio.Play();
        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play(); */
        nextFire = Time.time + fireRate;

        Rigidbody bullet = null;
        bullet = Instantiate(grenadeCasing);
        bullet.transform.rotation = transform.rotation;
        bullet.transform.position = transform.position;
        bullet.velocity = transform.TransformDirection(new Vector3(0,0,1) * ejectSpeed);
    }
}
