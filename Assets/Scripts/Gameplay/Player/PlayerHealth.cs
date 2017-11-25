using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts.Others;
using System.Collections.Generic;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth pHealth;

    public float startingHealth = 100f;                 
    public float currentHealth;
    public float startingArmor = 10f;
    public float armor;
    
    public Slider healthSlider;
    public Image FillImage;                           
    public Color FullHealthColor = Color.green;      
    public Color ZeroHealthColor = Color.red;       

    public Image damageImage;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);


    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    IList<Quest> quests;
    bool isDead;
    bool damaged;
    bool quest_active;
    int nb_quests;

    public ParticleSystem heal_dust;
    public GameObject aura;

    private bool forcefield = false;

    void Awake ()
    {
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        nb_quests = 0;
        SetHealthUI();      //new
    }


    void FixedUpdate ()
    {
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


    void Death ()
    {
        isDead = true;

        anim.SetTrigger ("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play ();

        playerMovement.enabled = false;
        StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel ()
    {
        yield return new WaitForSeconds(2f);
        SceneLoading.Instance.loadScene(SceneManager.GetActiveScene().name);
    }

    public void SetHealthUI() //new
    {
        
        healthSlider.value = currentHealth;

        
        FillImage.color = Color.Lerp(ZeroHealthColor, FullHealthColor, currentHealth / startingHealth);
    }

    public void ForceField(bool isActive)
    {
        forcefield = isActive;
    }
}
