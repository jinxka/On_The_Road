using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.Others;
using System.Collections.Generic;


public class PlayerHealth : MonoBehaviour
{
    #region UnityCompliant Singleton
    public static PlayerHealth Instance
    {
        get;
        private set;
    }

    public virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }
    #endregion

    public static PlayerHealth pHealth;

    public float maxHealth = 100f;                 
    public float currentHealth = 100f;
    public float startingArmor = 10f;
    public float armor;
    
    public Slider healthSlider;
    public Image FillImage;
    public Image damageImage;
    public Color FullHealthColor = Color.green;      
    public Color ZeroHealthColor = Color.red;       

    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    public Animator anim;
    public AudioSource playerAudio;
    public PlayerMovement playerMovement;
    public Tir_normal playerShooting;
    IList<Quest> quests;
    bool isDead;
    bool damaged;
    bool quest_active;
    int nb_quests;

    public ParticleSystem heal_dust;
    public GameObject aura;

    private bool forcefield = false;

    void Start ()
    {
        nb_quests = 0;
        SetHealthUI();      //new
    }

    void FixedUpdate ()
    {
        if (healthSlider == null)
            GetGUI();
        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        SetHealthUI(); //new

        playerAudio.Play ();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

    void GetGUI()
    {
        healthSlider = GameObject.FindGameObjectWithTag("HealthSlider").GetComponent<Slider>();
        FillImage = GameObject.FindGameObjectWithTag("Fill").GetComponent<Image>();
        //damageImage = GameObject.FindGameObjectWithTag("DamageImage").GetComponent<Image>();
        SetHealthUI();
    }

    void Death ()
    {
        isDead = true;

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
    }

    public void SetHealthUI() //new
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
            FillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, currentHealth / maxHealth);
        }
    }

    public void ForceField(bool isActive)
    {
        forcefield = isActive;
    }
}
