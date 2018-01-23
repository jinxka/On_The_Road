using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour {

    private PlayerHealth playerHealth;
    private Tir_normal playerShooting;
    private PlayerMovement playerMovement;
    private GameObject player;

    [SerializeField]
    Text characterDetails;

	void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerShooting = player.GetComponentInChildren<Tir_normal>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

	// Update is called once per frame
	void Update () {
        characterDetails.text = "Character Stats \n" +
            "\nWeapon Damage : " + playerShooting.BulletDmg +
            "\nAttacks per Second : " + (Mathf.Round((1 / playerShooting.fireRate) * 100f) / 100f) +
            "\nDamage per Second : " + (Mathf.Round((playerShooting.BulletDmg/ playerShooting.fireRate) * 100f) / 100f) +
            "\n" +
            "\nMaximum Health : " + playerHealth.maxHealth +
            "\nArmor : " + playerHealth.startingArmor + 
            "\n" +
            "\nMovement Speed : " + playerMovement.speed + "%";
	}
}
