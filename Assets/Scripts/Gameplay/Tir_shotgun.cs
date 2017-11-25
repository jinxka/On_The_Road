using UnityEngine;
using System.Collections;

public class Tir_shotgun : MonoBehaviour {
    public Rigidbody shrapnelCasing = null;
    public int ejectSpeed = 50;
    public float fireRate = 1F;
    public string reload_Key = "r";
    private float nextFire = 0.0F;

    //Clip systeme
    public int clip;
    public int clipSize = 6;
    public int ammoLeft = 60;
    public int ammoMax = 60;

    ParticleSystem gunParticles;
    AudioSource gunAudio;
    Light gunLight;

    public int BulletDmg;
    private BuffDegats buffdmg;

    void Awake()
    {
        buffdmg = GetComponentInParent<BuffDegats>();
        gunParticles = GetComponent<ParticleSystem>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if (clip >= 1)
            {
                shoot();
                clip = clip - 1;
            }
        }
        else
        {
            DisableEffects();
            if (Input.GetKeyDown(reload_Key) && (clip < clipSize))
            {
                reload();
            }
        }
    }

    void reload()
    {
        int reload = 0;
        reload = clipSize - clip;
        if (reload > ammoLeft)
        {
            clip = clip + ammoLeft;
            ammoLeft = 0;
        }
        else
        {
            clip = clip + reload;
            ammoLeft = ammoLeft - reload;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 130, 25), clip + " / " + ammoLeft);
    }

    public void DisableEffects()
    {
        gunLight.enabled = false;
    }

    public void shoot()
    {
        gunAudio.Play();
        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play();

        nextFire = Time.time + fireRate;
        Rigidbody[] Shrapnels = new Rigidbody[5];

        for (int i = 0; i < 5; i++)
        {
            Shrapnels[i] = Instantiate(shrapnelCasing);
            Shrapnels[i].transform.rotation = transform.rotation;
            Shrapnels[i].transform.position = transform.position;
            if ((buffdmg != null) && (buffdmg.buffDegats))
            {
                Shrapnels[i].GetComponent<Script_balle>().setDmg(BulletDmg * buffdmg.damageX);
            }
            else
            {
                Shrapnels[i].GetComponent<Script_balle>().setDmg(BulletDmg);
            }
        }
        Shrapnels[0].velocity = transform.TransformDirection(new Vector3(-0.30f, 0, 1) * ejectSpeed);
        Shrapnels[1].velocity = transform.TransformDirection(new Vector3(-0.15f, 0, 1) * ejectSpeed);
        Shrapnels[2].velocity = transform.TransformDirection(new Vector3(0, 0, 1) * ejectSpeed);
        Shrapnels[3].velocity = transform.TransformDirection(new Vector3(0.15f, 0, 1) * ejectSpeed);
        Shrapnels[4].velocity = transform.TransformDirection(new Vector3(0.30f, 0, 1) * ejectSpeed);
    }
}
