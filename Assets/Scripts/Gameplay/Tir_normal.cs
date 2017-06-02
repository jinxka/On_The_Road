using UnityEngine;
using System.Collections;

public class Tir_normal : MonoBehaviour
{
    public Rigidbody bulletCasing = null;
    public int ejectSpeed = 100;
    public float fireRate = 0.5F;
    public float quickFireRate = 0.0F;
    public string fireMode_Key = "v";
    public string reload_Key = "r";

    private float nextFire = 0.0F;
    private bool fullAuto = false;

    public int BulletDmg;
    private BuffDegats buffdmg;

    //Clip systeme
    public int clip;
    public int clipSize = 30;
    public int ammoLeft = 90;
    public int ammoMax = 90;

    ParticleSystem gunParticles;
    AudioSource gunAudio;
    Light gunLight;

    void Awake()
    {
        buffdmg = GetComponentInParent<BuffDegats>();
        gunParticles = GetComponent<ParticleSystem>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    void Start ()
    {
        clip = clipSize;
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
            if (Input.GetKeyDown(fireMode_Key))
            {
                fullAuto = !fullAuto;
            }
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

        if (fullAuto)
        {
            nextFire = Time.time + quickFireRate;
        }
        else
        {
            nextFire = Time.time + fireRate;
        }
        Rigidbody bullet = null;
        bullet = Instantiate(bulletCasing);
        if ((buffdmg != null) && (buffdmg.isBuffActive()))
        {
            bullet.GetComponent<Script_balle>().setDmg(BulletDmg * buffdmg.getDmgX());
        }
        else
        {
            bullet.GetComponent<Script_balle>().setDmg(BulletDmg);
        }
        bullet.transform.rotation = transform.rotation;
        bullet.transform.position = transform.position;
        bullet.velocity = transform.TransformDirection(Vector3.forward * ejectSpeed);
    }

}
