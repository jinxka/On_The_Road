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
        if ((!EventSystem.current.IsPointerOverGameObject()) && GUIManager.Instance.allPanelsAreClosed)
        {
            if (Input.GetButton("Fire1") && (Time.time > nextFire))
            {
                if (clip >= 1)
                {
                    shoot();
                    clip = clip - 1;
                }
                else
                    AudioManager.instance.Play("EmptyAk");
            }
            else
                DisableEffects();
        }
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
		AudioManager.instance.Play("AkReload");
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
        //gunAudio.Play();
		AudioManager.instance.Play("AkShoot");
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
        bullet.transform.Rotate(Vector3.right * 90);
        bullet.GetComponent<Script_balle>().setDmg(BulletDmg);
    }

    public void setBulletDmg(int dmg)
    {
        BulletDmg = dmg;
    }

}
