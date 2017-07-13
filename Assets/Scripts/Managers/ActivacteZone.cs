using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivacteZone : MonoBehaviour {
	public GameObject [] gameobjects;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player) {
			foreach (GameObject gameobject in gameobjects) {
				gameobject.SetActive(true);
			}
		}
	}
}
