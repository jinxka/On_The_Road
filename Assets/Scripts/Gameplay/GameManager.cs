using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Color myFadeColor;

	GameObject player;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.currentHealth <= 0)
			StartCoroutine (TryAgain ());
	}



	IEnumerator TryAgain()
	{
		yield return new WaitForSeconds (3);
		Initiate.Fade(SceneManager.GetActiveScene ().name, myFadeColor, 0.7f);
	}
}
