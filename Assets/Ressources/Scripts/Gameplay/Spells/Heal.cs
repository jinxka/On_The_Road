using UnityEngine;
using System.Collections;

public class Heal : MonoBehaviour {

    public int healPower = 20;
    public float cooldown = 10.0F;

    private PlayerHealth playerHealth;
    private float timer = 0.0F;

    public ParticleSystem heal_dust;
    public string shortcut;

    public float Duration = 0.5F;
    private float BuffDuration = 0.0f;

    // Use this for initialization
    void Start () {
        playerHealth = GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton(shortcut) && Time.time >= timer && Time.timeScale != 0)
        {
            heal_dust.Play();
            playerHealth.currentHealth = playerHealth.currentHealth + healPower;
            playerHealth.SetHealthUI();
            timer = Time.time + cooldown;
        }
        else if (Time.time > BuffDuration)
        {
            heal_dust.Stop();
        }
	}
}
