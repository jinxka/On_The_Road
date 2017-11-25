using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

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
    void FixedUpdate()
    {
		if ((clip >= 1) && Input.GetButton ("Fire1") && (Time.time > nextFire) && !EventSystem.current.IsPointerOverGameObject ()) {
			shoot ();
			clip = clip - 1;
		} 
		else
			DisableEffects ();
        if (Input.GetKeyDown(fireMode_Key))
        {
            fullAuto = !fullAuto;
        }
        if (Input.GetKeyDown(reload_Key) && (clip < clipSize))
        {
            reload();
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
		Rigidbody bullet = Instantiate (bulletCasing, transform.position, transform.rotation);
		bullet.velocity = transform.TransformDirection(Vector3.forward * ejectSpeed);
        if ((buffdmg != null) && (buffdmg.buffDegats))
        {
            bullet.GetComponent<Script_balle>().setDmg(BulletDmg * buffdmg.damageX);
        }
        else
        {
            bullet.GetComponent<Script_balle>().setDmg(BulletDmg);
        }
    }

}
