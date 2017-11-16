using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour {

    public PlayerHealth playerHealth;
    public Tir_normal playerShooting;
    public PlayerMovement playerMovement;
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = "Character Stats \n" +
            "\nWeapon Damage : " + playerShooting.BulletDmg +
            "\nAttacks per Second : " + (Mathf.Round((1 / playerShooting.fireRate) * 100f) / 100f) +
            "\nDamage per Second : " + (Mathf.Round((playerShooting.BulletDmg/ playerShooting.fireRate) * 100f) / 100f) +
            "\n" +
            "\nMaximum Health : " + playerHealth.startingHealth +
            "\nArmor : " + playerHealth.startingArmor + 
            "\n" +
            "\nMovement Speed : " + playerMovement.speed + "%";
	}
}
