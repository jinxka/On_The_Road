using UnityEngine;
using System.Collections;

public class Shotgun_special : MonoBehaviour {
    public Rigidbody shrapnelSpecialCasing = null;
    public int ejectSpeed = 50;
    public float fireRate = 1F;

    private float nextFire = 0.0F;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2") && Time.time > nextFire)
        {
                shotgun_special();
        }
    }

    public void shotgun_special()
    {
        /*
        gunAudio.Play();
        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play(); */
        nextFire = Time.time + fireRate;

        Rigidbody[] Shrapnels = new Rigidbody[11];

        for (int i = 0; i < 5; i++)
        {
            Shrapnels[i] = Instantiate(shrapnelSpecialCasing);
            Shrapnels[i].transform.rotation = transform.rotation;
            Shrapnels[i].transform.position = transform.position;
        }
        Shrapnels[0].velocity = transform.TransformDirection(new Vector3(-0.80f, 0, 1) * ejectSpeed);
        Shrapnels[1].velocity = transform.TransformDirection(new Vector3(-0.40f, 0, 1) * ejectSpeed);
        Shrapnels[2].velocity = transform.TransformDirection(new Vector3(0f, 0, 1) * ejectSpeed);
        Shrapnels[3].velocity = transform.TransformDirection(new Vector3(0.40f, 0, 1) * ejectSpeed);
        Shrapnels[4].velocity = transform.TransformDirection(new Vector3(0.80f, 0, 1) * ejectSpeed);
    }
}
