using UnityEngine;
using System.Collections;

public class Medikits : MonoBehaviour {

    public int healPower = 5;
    public float cooldown = 30.0F;
    public float Duration = 10.0F;
    private PlayerHealth playerHealth;
    private float second = 0;
    public ParticleSystem heal_dust;


    // Use this for initialization
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }


    IEnumerator UseMedikit()
    {
        heal_dust.Play();
        second = Time.time - 1F;
        for (float i = Time.time; (Time.time - i) <= Duration; )
        {
            if (Time.time - second > 1F)
            {
                playerHealth.currentHealth = playerHealth.currentHealth + healPower;
                playerHealth.SetHealthUI();
                second = Time.time;
            }
        }
        heal_dust.Stop();
        return null;
    }

    public void UseSpell()
    {
        UseMedikit();
    }

    public float GetCooldown()
    {
        return cooldown;
    }
}
