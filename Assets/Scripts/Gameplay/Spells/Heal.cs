using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour, ISpell {

    public int healPower = 20;
    public float cooldown = 10.0F;
    public float duration = 0;

    private PlayerHealth playerHealth;

    public ParticleSystem heal_dust;

    // Use this for initialization
    void Start () {
        playerHealth = GetComponent<PlayerHealth>();
	}

    public void UseSpell()
    {
        heal_dust.Play();
        playerHealth.currentHealth = playerHealth.currentHealth + healPower;
        playerHealth.SetHealthUI();
    }
    
    public float GetCooldown()
    {
        return cooldown;
    }
}
