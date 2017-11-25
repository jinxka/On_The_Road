using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Heal : MonoBehaviour {

    public int healPower = 20;
    public float cooldown = 10.0F;
    public float duration = 0;
    public Image cooldownImage;

    private PlayerHealth playerHealth;

    ParticleSystem heal_dust;
    bool onCooldown = false;
    float currentTime;

    // Use this for initialization
    void Start () {
       
	}

    public void UseSpell()
    {
        if (onCooldown)
            return;
        if (playerHealth == null)
            setVariables();
        heal_dust.Play();
        if ((playerHealth.currentHealth + healPower) <= playerHealth.startingHealth)
            playerHealth.currentHealth = playerHealth.currentHealth + healPower;
        else
            playerHealth.currentHealth = playerHealth.startingHealth;
        playerHealth.SetHealthUI();
 
        currentTime = cooldown;
        cooldownImage.enabled = true;
        cooldownImage.fillAmount = 1f;
        StartCoroutine(triggerCooldown());
    }

    private IEnumerator triggerCooldown()
    {
        onCooldown = true;
        while (cooldownImage.fillAmount > 0)
        {
            currentTime -= Time.deltaTime;
            cooldownImage.fillAmount = currentTime / cooldown;
            yield return null;
        }
        onCooldown = false;
        cooldownImage.enabled = false;
    }

    void setVariables()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        heal_dust = playerHealth.heal_dust;
    }
}
