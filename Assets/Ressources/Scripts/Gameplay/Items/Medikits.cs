using UnityEngine;
using System.Collections;

public class Medikits : MonoBehaviour {

    public int healPower = 5;
    public float cooldown = 30.0F;

    private PlayerHealth playerHealth;
    private float timer = 0.0F;

    public ParticleSystem heal_dust;
    public string shortcut;

    public float Duration = 10.0F;
    public float ticks = 1F;
    private float BuffDuration = 0.0f;
    private float PreviousTick = 0.0f;
    private bool isBuffActive = false;


    // Use this for initialization
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton(shortcut) && Time.time >= timer && Time.timeScale != 0)
        {
            activeBuff();
        }
        else if (Time.time > BuffDuration)
        {
            deactiveBuff();
        }

        if(isBuffActive && (Time.time - PreviousTick) >= 1F)
        {
            playerHealth.currentHealth = playerHealth.currentHealth + healPower;
            playerHealth.SetHealthUI();
            PreviousTick = Time.time;
        }
    }

    void activeBuff()
    {
        heal_dust.Play();
        timer = Time.time + cooldown;
        isBuffActive = true;
        timer = Time.time + Duration + cooldown;
        BuffDuration = Time.time + Duration;
    }

    void deactiveBuff()
    {
        heal_dust.Stop();
        isBuffActive = false;
    }
}
